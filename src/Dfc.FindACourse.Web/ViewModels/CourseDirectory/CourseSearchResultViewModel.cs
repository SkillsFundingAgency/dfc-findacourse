using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Models.CourseDirectory
{
    public class CourseSearchResultViewModel
    {
        public string SortyBy { get; set; }
        public int StartNo { get; set; }
        public int EndNo { get; set; }
        public int NoOfRecords { get; set; }
        public int PageNo { get; set; }
        public int NoOfPages { get; set; }
        public List<CourseSearchResultItemViewModel> Items { get; set; }
    }
}
