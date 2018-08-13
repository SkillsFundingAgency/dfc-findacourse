using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Models
{
    public class CourseSearchRequestModel
    {
        public string Course { get; set; }
        public string QualificationLevel { get; set; }
        public string LocationPostCodeTown { get; set; }
        public int LocationRadius { get; set; }
        public string LocationCoordinates { get; set; }
    }
}
