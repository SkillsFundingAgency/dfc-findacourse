using System.Collections.Generic;
using System.Xml;
using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface ICourseDirectoryHelper
    {
        List<QualLevel> QualificationLevels(ICourseSearchRequestModel requestModel);
        List<StudyModeExt> StudyModes(ICourseSearchRequestModel requestModel);
        IEnumerable<string> GetMatches(string search, XmlNodeList expnData);
        IEnumerable<string> GetMissSpellings(string search, XmlDocument searchTerms, XmlNodeList expnData);
        bool HasQualificationLevels(ICourseSearchRequestModel requestModel);
        List<string> AttendanceModes(ICourseSearchRequestModel requestModel);
    }
}