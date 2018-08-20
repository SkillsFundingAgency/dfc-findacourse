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
    public static class FileHelper
    {

        /// <summary>
        /// Download and persist the file to the web server
        /// Then we can validate that it is properly formed XML, has expansion and sub entries
        /// If it passes validation, we will overwrite the file currently on the site
        /// </summary>
        /// <param name="blobsynname"></param>
        /// <param name="webfilename"></param>
        /// <returns></returns>
        public static async Task DownloadSynonymFile(string blobSynname, string tempFilename, string synonymFileName)
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                                        "ncsfindacourse",  //"dfcdevfacostr",
                                            "84+Q/HYoPpcFc+Anq52GjmXP62DskRm8adL4p9wEEv0TJOwrupIdAP7Z5gD4VdrOhQwuzmqAhNcFzFvcmGoN2w=="), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlockBlob blockBlob;
            MemoryStream ms = new MemoryStream();
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference("ncsfacsynonyms"); 
                blockBlob = container.GetBlockBlobReference(blobSynname);
               
                using (var fileStream = System.IO.File.OpenWrite(string.Format(@"Data\\{0}", tempFilename)))
                {
                    await blockBlob.DownloadToStreamAsync(fileStream);
                }
                CopyOverSynFile(string.Format(@"Data\\{0}", tempFilename), string.Format(@"Data\\{0}", synonymFileName));
            }
            catch (StorageException)
            {
                //TODO Add logging
            }
          
        }

        public static async Task DownloadConfigFiles(string blobname, string tempFilename, string replaceFileName)
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                                          "ncsfindacourse",  //"dfcdevfacostr",
                                            "84+Q/HYoPpcFc+Anq52GjmXP62DskRm8adL4p9wEEv0TJOwrupIdAP7Z5gD4VdrOhQwuzmqAhNcFzFvcmGoN2w=="), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlockBlob blockBlob;
            MemoryStream ms = new MemoryStream();
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference("ncsdropdownconfig");
                blockBlob = container.GetBlockBlobReference(blobname);

                using (var fileStream = System.IO.File.OpenWrite(string.Format(@"Data\\{0}", tempFilename)))
                {
                    await blockBlob.DownloadToStreamAsync(fileStream);
                }
                CopyOverConfigFile(string.Format(@"Data\\{0}", tempFilename), string.Format(@"Data\\{0}", replaceFileName));
            }
            catch (StorageException)
            {
                //TODO Add logging
            }

        }

        public static void CopyOverSynFile(string tempFile, string destFile)
        {
            if(ValidateSynonymsFile(tempFile))
                File.Copy(tempFile, destFile, true);
            
        }
        public static void CopyOverConfigFile(string tempFile, string destFile)
        {
            if (ValidateConfigFile(tempFile))
                File.Copy(tempFile, destFile, true);

        }
        public static bool ValidateConfigFile(string strInput)
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

        public static bool ValidateSynonymsFile(string tempfilename)
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
        /// <summary>
        /// Load synonyms file or get from cache
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <returns></returns>
        public static XmlDocument LoadSynonyms(IMemoryCache memoryCache)
        {
            XmlDocument searchTerms = new XmlDocument();
            if (!memoryCache.TryGetValue(CacheKeys.Synonyms, out searchTerms))
            {
                //TODO - Add configuration for filepath and name
                //If it doesn't exist download it
                if (!System.IO.File.Exists("Data\\tsenu.xml"))
                {
                    FileHelper.DownloadSynonymFile("tsenu2.xml", "tsenu2.xml", "tsenu.xml").Wait();
                }
                //Check that it is now available
                
                if (System.IO.File.Exists("Data\\tsenu.xml"))
                {
                    searchTerms = new XmlDocument();
                    searchTerms.Load("Data\\tsenu.xml");
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(23));
                    memoryCache.Set(CacheKeys.Synonyms, searchTerms, cacheEntryOptions);
                }


            }
            return searchTerms;
        }
    }
}
