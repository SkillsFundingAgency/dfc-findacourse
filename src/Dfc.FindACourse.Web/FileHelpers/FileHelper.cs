using Dfc.FindACourse.Common.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Dfc.FindACourse.Web
{
    /// <summary>
    /// class that downloads files from Azure storage to temp folder
    /// Validates the data
    /// then caches that data in Memcache for the application to use
    /// </summary>
    public class FileHelper
    {
        public IConfiguration _configuration;
        private IMemoryCache _cache;
        private string _storagename;
        private string _storagekey;
        private string _containername;


        public FileHelper(IConfiguration configuration, IMemoryCache cache)
        {
            _configuration = configuration;
            _cache = cache;
            _storagename = _configuration["Storage:Storage_AccountName"];
            _storagekey = _configuration["Storage:Storage_AccountKey"];
            _containername = _configuration["Storage:Storage_ContainerReference"];
        }

        /// <summary>
        /// Generic method to download from blob and copy to app settings temp folder
        /// </summary>
        /// <param name="blobSynname"></param>
        /// <param name="tempFilename"></param>
        /// <param name="synonymFileName"></param>
        /// <returns></returns>
        public async Task<bool> DownloadFile(string blobFileName, string tempfolder)
        {
            //Set up the client
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                                        _storagename, //"ncsfindacourse",  //"dfcdevfacostr",
                                           _storagekey), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
           
            MemoryStream ms = new MemoryStream();
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference(_containername);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobFileName); 

                var existsAsync = blockBlob.ExistsAsync();
                existsAsync.Wait();
               
                if (existsAsync.Result)
                {

                    using (var fileStream = System.IO.File.OpenWrite(System.IO.Path.Combine(tempfolder, blobFileName)))
                    {
                        await blockBlob.DownloadToStreamAsync(fileStream);
                    }
                }
                else
                    return false;
                
            }
            catch (StorageException stex)
            {
                //TODO Add logging
                return false;
            }
            catch(Exception ex)
            {
                //TODO Add logging
                return false;
            }
            return true;

        }
        /// <summary>
        /// Download and persist the file to the web server
        /// Then we can validate that it is properly formed XML, has expansion and sub entries
        /// If it passes validation, we will overwrite the file currently on the site
        /// </summary>
        /// <param name="blobsynname"></param>
        /// <param name="webfilename"></param>
        /// <returns></returns>
        public async Task DownloadSynonymFile()
        {
            string storageSynName = _configuration["Storage:Storage_SynonymsFilename"];
            string tempPath = _configuration["ConfigSettings:App_TempSynonymFilePath"];
            string tempFile = System.IO.Path.Combine(tempPath, storageSynName);
            string configFile = System.IO.Path.Combine(_configuration["ConfigSettings:App_SynonymFilePath"], _configuration["ConfigSettings:App_SynonymFileName"]);

            var success = await DownloadFile(storageSynName, tempPath);

            if (success && ValidateSynonymsFile(tempFile))
            { 
                File.Copy(tempFile, configFile, true);
                //Now cache
                XmlDocument searchTerms = new XmlDocument();
                searchTerms.Load(System.IO.Path.Combine(_configuration["ConfigSettings:App_SynonymFilePath"], _configuration["ConfigSettings:App_SynonymFileName"]));

                CacheHelper.CacheFile(_cache, searchTerms, CacheKeys.Synonyms);
            }


        }
      
        /// <summary>
        /// This will download the config files from BLOB, save them to the web server temp folder, validate the data, copy to Data Folder and then cache in memory
        /// </summary>
        /// <returns></returns>
        public async Task DownloadConfigFiles()
        {
            string storageName = _configuration["Storage:Storage_QualSettingsFilename"];
            string tempPath = _configuration["ConfigSettings:App_TempSettingsFilePath"];
            string tempFilePath= System.IO.Path.Combine(tempPath, storageName);
            string configFilePath = System.IO.Path.Combine(_configuration["ConfigSettings:App_SettingsFilePath"], _configuration["ConfigSettings:App_QualSettingsFileName"]);

            var success = await DownloadFile(storageName, tempPath);

            if (success && ValidateConfigFile(tempFilePath))
            { 
                File.Copy(tempFilePath, configFilePath, true);
                //now cache the data
                using (StreamReader r = new StreamReader(configFilePath))
                {
                    CacheHelper.CacheFile(_cache, JsonConvert.DeserializeObject<List<QualLevel>>(r.ReadToEnd()), CacheKeys.QualificationLevels);
                    r.Close();
                }

            }
        }

     
        #region validation
        public bool ValidateConfigFile(string tempFile)
        {
            string strInput = string.Empty;
            using (StreamReader r = new StreamReader(tempFile))
            {
                strInput = r.ReadToEnd();
                r.Close();
            }

            if (!string.IsNullOrEmpty(strInput))
            {
                strInput = strInput.Trim();
                if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                    (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
                {
                    try
                    {
                        var obj = JToken.Parse(strInput);
                        return true;
                    }
                    catch (JsonReaderException jex)
                    {
                        //Exception in parsing json
                        Console.WriteLine(jex.Message);
                        return false;
                    }
                    catch (Exception ex) //some other exception
                    {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidateSynonymsFile(string tempfilename)
        {
            try
            {
                //Load and parse XML
                XmlDocument searchTerms = new XmlDocument();
                searchTerms.Load(tempfilename);
                int expansion = 0;
                int sub = 0;
                foreach (XmlNode nData in searchTerms.GetElementsByTagName("expansion"))
                {
                    expansion++;
                    XmlNodeList oNode = nData.SelectNodes(".//sub");
                    foreach (XmlNode nChilddata in oNode)
                            sub++;

                }

                    return expansion > 0 && sub > 0;
            }
            catch
            {

                return false;

            }



        }
        #endregion

        #region caching
        /// <summary>
        /// Load synonyms file or get from cache
        /// </summary>
        /// <returns></returns>
        public XmlDocument LoadSynonyms()
        {
            XmlDocument searchTerms = new XmlDocument();
            if (!_cache.TryGetValue(CacheKeys.Synonyms, out searchTerms))
            {
                if (!System.IO.File.Exists(System.IO.Path.Combine(_configuration["ConfigSettings:App_SynonymFilePath"], _configuration["ConfigSettings:App_SynonymFileName"])))
                {
                    DownloadSynonymFile().Wait();
                }
                else //since it exists and it is not cached, Cache it now
                {
                    searchTerms = new XmlDocument();
                    searchTerms.Load(System.IO.Path.Combine(_configuration["ConfigSettings:App_SynonymFilePath"], _configuration["ConfigSettings:App_SynonymFileName"]));
                    CacheHelper.CacheFile(_cache, searchTerms, CacheKeys.Synonyms);
                }


            }
            return searchTerms;
        }
        public IEnumerable<QualLevel> LoadQualificationLevels()
        {
            IEnumerable<QualLevel> qualificationlevels = null;
            if (!_cache.TryGetValue(CacheKeys.QualificationLevels, out qualificationlevels))
            {
                if (!System.IO.File.Exists(System.IO.Path.Combine(_configuration["ConfigSettings:App_SettingsFilePath"], _configuration["ConfigSettings:App_QualSettingsFileName"])))
                 {
                    DownloadConfigFiles().Wait();
                }
                //since it exists and it is not cached, cache it now
                else
                { 
                    using (StreamReader r = new StreamReader(System.IO.Path.Combine(_configuration["ConfigSettings:App_SettingsFilePath"], _configuration["ConfigSettings:App_QualSettingsFileName"])))
                    {
                        qualificationlevels = JsonConvert.DeserializeObject<List<QualLevel>>(r.ReadToEnd());
                        CacheHelper.CacheFile(_cache, qualificationlevels, CacheKeys.QualificationLevels);
                       
                        r.Close();
                    }
                }


            }
            return qualificationlevels;
        }
        
        #endregion

    }
    public static class CacheHelper
    {
        public static void CacheFile<TItem>(IMemoryCache cache, TItem file, string fileKey)
        {
            TItem data = cache.GetOrCreate(fileKey, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(23);
                return file;
            });
        }
        private static TItem GetOrCreate<TItem>(this IMemoryCache cache, object key, Func<ICacheEntry, TItem> factory)
        {
            object obj;
            if (!cache.TryGetValue(key, out obj))
            {
                ICacheEntry entry = cache.CreateEntry(key);
                obj = (object)factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
            }
            return (TItem)obj;
        }
    }

}
