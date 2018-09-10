using System.Collections.Generic;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Web.RequestModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface ICourseDirectory
    {
        IEnumerable<SelectListItem> GetQualificationLevels();

        IEnumerable<string> AutoSuggestCourseName(string search);
        ICourseSearchCriteria CreateCourseSearchCriteria(CourseSearchRequestModel requestModel);
    }
}