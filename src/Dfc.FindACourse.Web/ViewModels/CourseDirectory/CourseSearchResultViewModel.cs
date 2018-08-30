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
        private IResult<CourseSearchResult> result;

        public CourseSearchResultViewModel(IResult<CourseSearchResult> result)
        {
            NoOfRecords = result.Value.NoOfRecords;
            NoOfPages = result.Value.NoOfPages;
            Items = result.Value.Items.Select(x => new CourseSearchResultItemViewModel(x)).ToList();
        }

        public string SortyBy { get; set; }
        public int StartNo { get; set; }
        public int EndNo { get; set; }
        public int NoOfRecords { get; set; }
        public int PageNo { get; set; }
        public int NoOfPages { get; set; }
        public List<CourseSearchResultItemViewModel> Items { get; set; }
    }
}
