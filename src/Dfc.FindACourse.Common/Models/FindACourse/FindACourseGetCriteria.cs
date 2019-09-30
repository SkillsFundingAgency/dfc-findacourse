using Dfc.FindACourse.Common.Interfaces.FindACourse.CourseGet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models.FindACourse
{
    public class FindACourseGetCriteria : IFindACourseGetCriteria
    {
        public string CourseId { get; }
        public string RunId { get; }

        public FindACourseGetCriteria(string courseid, string runid)
        {
            CourseId = courseid;
            RunId = runid;
        }
    }
}
