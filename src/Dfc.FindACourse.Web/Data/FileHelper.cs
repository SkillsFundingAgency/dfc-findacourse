using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web
{
    public class FileHelper
    {
        public async Task<bool> DownloadFile(int id)
        {
            //var debitMemo = await _context.DebitMemo
            //    .SingleOrDefaultAsync(m => m.ID == id);

            //CloudBlockBlob blockBlob;
            //MemoryStream ms = new MemoryStream();
            //try
            //{
            //    CloudBlobContainer container = DebitMemo.GetAzureContainer();
            //    blockBlob = container.GetBlockBlobReference(debitMemo.BlobName);
            //    await container.CreateIfNotExistsAsync();
            //    // Save blob contents to a file.
            //    await blockBlob.DownloadToStreamAsync(ms);

            //    Stream blobStream = await blockBlob.OpenReadAsync();

            //    return File(blobStream, blockBlob.Properties.ContentType, debitMemo.BlobName);
            //}
            //catch (StorageException)
            //{
            //    return Content("File does not exist");
            //}
            return false;
        }
    }
}
