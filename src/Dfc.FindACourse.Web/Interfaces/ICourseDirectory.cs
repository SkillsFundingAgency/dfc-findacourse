﻿using System;
using System.Collections.Generic;
using Dfc.FindACourse.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface ICourseDirectory
    {
        IEnumerable<SelectListItem> GetQualificationLevels();
        IEnumerable<string> AutoSuggestCourseName(string search);
        ICourseSearchCriteria CreateCourseSearchCriteria(ICourseSearchRequestModel requestModel);
        bool IsSuccessfulResult<T>(IResult<T> result, ITelemetryClient telemetryClient, string methodName,
            string value, DateTime dtStart);
    }
}