using System.Collections.Generic;
using System.Xml;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface ICourseDirectoryHelper
    {
        List<QualLevel> QualificationLevels(ICourseSearchRequestModel requestModel, IFileHelper files);
        List<StudyModeExt> StudyModes(ICourseSearchRequestModel requestModel);
        IEnumerable<string> GetMatches(string search, XmlNodeList expnData);
        IEnumerable<string> GetMissSpellings(string search, XmlDocument searchTerms, XmlNodeList expnData);
        int GetQualificationLevel(string qualificationLevel);
    }
}