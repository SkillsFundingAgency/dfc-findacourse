using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class CourseSearchResultViewModel
    {
        public CourseSearchResultViewModel(IResult<CourseSearchResult> result)
        {
            NoOfRecords = result.Value.NoOfRecords;
            NoOfPages = result.Value.NoOfPages;
            PageNo = result.Value.PageNo;
            Items = result.Value.Items.Select(x => new CourseSearchResultItemViewModel(x)).ToList();
            DefaultRadiusDistance = RadiusDistance.Miles10;
        }

        public string ShowingFrom()
        {
            if (PageNo <= 1)
                return 1.ToString();

            var from = (PageNo - 1) * PerPage + 1;

            return from.ToString();
        }

        public string ShowingTo()
        {
            if (PageNo <= 1 && PerPage >= NoOfRecords)
                return NoOfRecords.ToString();

            if (PageNo <= 1 && PerPage < NoOfRecords)
                return PerPage.ToString();

            var to = ((PageNo - 1) * PerPage) + PerPage;

            to = to > NoOfRecords ? NoOfRecords : to;

            return to.ToString();
        }

        [Display(Name = "Course name")]
        [Required]
        public string SubjectKeyword { get; set; }
        public string Location { get; set; }
        public RadiusDistance DefaultRadiusDistance { get; set; }
        public string SortyBy { get; set; }
        public int StartNo { get; set; }
        public int EndNo { get; set; }
        public int NoOfRecords { get; set; }
        public int PageNo { get; set; }
        public int NoOfPages { get; set; }
        public int PerPage { get; set; }
        public List<CourseSearchResultItemViewModel> Items { get; set; }
    }
}
