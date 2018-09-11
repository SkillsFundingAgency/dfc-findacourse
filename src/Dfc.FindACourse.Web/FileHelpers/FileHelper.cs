using Dfc.FindACourse.Common.Models;
using Microsoft.ApplicationInsights;
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
using Dfc.FindACourse.Web.Interfaces;

namespace Dfc.FindACourse.Web
{
    /// <summary>
    /// class that downloads files from Azure storage to temp folder
    /// Validates the data
    /// then caches that data in Memcache for the application to use
    /// </summary>
    public class FileHelper : IFileHelper
    {
        public IConfiguration Configuration { get; }
        public IMemoryCache Cache { get; }
        public ITelemetryClient Telemetry { get; }

        private string _storagename;
        private string _storagekey;
        private string _containername;
        private ITelemetryClient _telemetry;


        public FileHelper(IConfiguration configuration, IMemoryCache cache, ITelemetryClient telemetryClient)
        {
            Configuration = configuration;
            Cache = cache;
            _storagename = Configuration["Storage:AccountName"];
            _storagekey = Configuration["Storage:AccountKey"];
            _containername = Configuration["Storage:ContainerReference"];
            _telemetry = telemetryClient;
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
                {
                    _telemetry.TrackEvent("DownloadFile", new Dictionary<string, string>()
                                                      {
                                                         { "BlobFileName", blobFileName },
                                                         { "Tempfolder", tempfolder }
                                                     });
            
                    return false;
                }
                
            }
            catch (StorageException stex)
            {
                _telemetry.TrackException(stex);
                return false;
            }
            catch(Exception ex)
            {
                _telemetry.TrackException(ex);
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
            string storageSynName = Configuration["Storage:SynonymsFilename"];
            string tempPath = Configuration["ConfigSettings:TempSynonymFilePath"];
            string tempFile = System.IO.Path.Combine(tempPath, storageSynName);
            string configFile = System.IO.Path.Combine(Configuration["ConfigSettings:SynonymFilePath"], Configuration["ConfigSettings:SynonymFileName"]);

            var success = await DownloadFile(storageSynName, tempPath);

            if (success && ValidateSynonymsFile(tempFile))
            { 
                File.Copy(tempFile, configFile, true);
                //Now cache
                XmlDocument searchTerms = new XmlDocument();
                searchTerms.Load(System.IO.Path.Combine(Configuration["ConfigSettings:SynonymFilePath"], Configuration["ConfigSettings:SynonymFileName"]));

                CacheHelper.CacheFile(Cache, searchTerms, CacheKeys.Synonyms);
            }


        }
      
        /// <summary>
        /// This will download the config files from BLOB, save them to the web server temp folder, validate the data, copy to Data Folder and then cache in memory
        /// </summary>
        /// <returns></returns>
        public async Task DownloadConfigFiles()
        {
            string storageName = Configuration["Storage:QualSettingsFilename"];
            string tempPath = Configuration["ConfigSettings:TempSettingsFilePath"];
            string tempFilePath= System.IO.Path.Combine(tempPath, storageName);
            string configFilePath = System.IO.Path.Combine(Configuration["ConfigSettings:SettingsFilePath"], Configuration["ConfigSettings:QualSettingsFileName"]);

            var success = await DownloadFile(storageName, tempPath);

            if (success && ValidateConfigFile(tempFilePath))
            { 
                File.Copy(tempFilePath, configFilePath, true);
                //now cache the data
                using (StreamReader r = new StreamReader(configFilePath))
                {
                    CacheHelper.CacheFile(Cache, JsonConvert.DeserializeObject<List<QualLevel>>(r.ReadToEnd()), CacheKeys.QualificationLevels);
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
                        _telemetry.TrackException(jex,
                                          new Dictionary<string, string>()
                                          {
                                             { "TempFile", tempFile }
                                         });
                        return false;
                    }
                    catch (Exception ex) //some other exception
                    {
                        _telemetry.TrackException(ex,
                                          new Dictionary<string, string>()
                                          {
                                             { "TempFile", tempFile }
                                         });
                        return false;
                    }
                }
                else
                {
                    _telemetry.TrackEvent("Config Failed Validation");
                    return false;
                }
            }
            else
            {
                _telemetry.TrackEvent("Config was empty");
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
            catch (Exception ex) //some other exception
            {
                _telemetry.TrackException(ex,
                      new Dictionary<string, string>()
                      {
                         { "Tempfilename", tempfilename }
                     });
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
            if (!Cache.TryGetValue(CacheKeys.Synonyms, out searchTerms))
            {
                if (!System.IO.File.Exists(System.IO.Path.Combine(Configuration["ConfigSettings:SynonymFilePath"], Configuration["ConfigSettings:SynonymFileName"])))
                {
                    DownloadSynonymFile().Wait();
                }
                else //since it exists and it is not cached, Cache it now
                {
                    searchTerms = new XmlDocument();
                    searchTerms.Load(System.IO.Path.Combine(Configuration["ConfigSettings:SynonymFilePath"], Configuration["ConfigSettings:SynonymFileName"]));
                    CacheHelper.CacheFile(Cache, searchTerms, CacheKeys.Synonyms);
                }


            }
            return searchTerms;
        }

        public IEnumerable<QualLevel> LoadQualificationLevels()
        {
            IEnumerable<QualLevel> qualificationlevels = null;
            if (!Cache.TryGetValue(CacheKeys.QualificationLevels, out qualificationlevels))
            {
                if (!System.IO.File.Exists(System.IO.Path.Combine(Configuration["ConfigSettings:SettingsFilePath"], Configuration["ConfigSettings:QualSettingsFileName"])))
                 {
                    DownloadConfigFiles().Wait();
                }
                //since it exists and it is not cached, cache it now
                else
                { 
                    using (StreamReader r = new StreamReader(System.IO.Path.Combine(Configuration["ConfigSettings:SettingsFilePath"], Configuration["ConfigSettings:QualSettingsFileName"])))
                    {
                        qualificationlevels = JsonConvert.DeserializeObject<List<QualLevel>>(r.ReadToEnd());
                        CacheHelper.CacheFile(Cache, qualificationlevels, CacheKeys.QualificationLevels);
                       
                        r.Close();
                    }
                }


            }
            return qualificationlevels;
        }
        
        #endregion

    }

}
