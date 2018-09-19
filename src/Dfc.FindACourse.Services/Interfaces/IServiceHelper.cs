using System.Collections.Generic;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Tribal;

namespace Dfc.FindACourse.Services.Interfaces
{
    public interface IServiceHelper
    {
        IEnumerable<CourseItem> CourseItems(CourseListResponseStructure response);
        string[] GetQualificationLevels(List<QualLevel> qualLevels);
        string GetTownOrPostcode(string value);
        float GetDistance(ICourseSearchCriteria searchCriteria);
        string GetDfe1619Funded(ICourseSearchCriteria searchCriteria);
        string[] GetStudyModes(ICourseSearchCriteria searchCriteria);
        bool IsDistanceSpecified(ICourseSearchCriteria searchCriteria);
    }
}