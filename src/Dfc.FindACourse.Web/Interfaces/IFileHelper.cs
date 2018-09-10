using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface IFileHelper
    {
        Task<bool> DownloadFile(string blobFileName, string folder);
        Task DownloadSynonymFile();
        Task DownloadConfigFiles();
        bool ValidateConfigFile(string fileName);
        bool ValidateSynonymsFile(string fileName);
        XmlDocument LoadSynonyms();
        IEnumerable<QualLevel> LoadQualificationLevels();
    }

}
