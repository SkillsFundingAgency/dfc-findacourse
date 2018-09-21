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
        private const string _locationError = "Enter a full and valid postcode";

        public CourseSearchResultViewModel(IResult<CourseSearchResult> result)
        {
            NoOfRecords = result.Value.NoOfRecords;
            NoOfPages = result.Value.NoOfPages;
            PageNo = result.Value.PageNo;
            Items = result.Value.Items.Select(x => new CourseSearchResultItemViewModel(x)).ToList();
            LocationRadius = RadiusDistance.Miles10;
        }

        public string ShowingFrom()
        {
            if (PageNo == 1 && NoOfRecords == 0)
                return 0.ToString();

            if (PageNo == 1)
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

        public string LocationRadiusChecked(int radius)
        {
            return (int)LocationRadius == radius ? "checked=\"checked\"" : string.Empty;
        }

        [Display(Name = "Course name")]
        [Required(ErrorMessage = "Enter a course name")]
        public string SubjectKeyword { get; set; }
        [Display(Name = "Postcode")]
        [RegularExpression(@"([a-zA-Z][0-9]|[a-zA-Z][0-9][0-9]|[a-zA-Z][a-zA-Z][0-9]|[a-zA-Z][a-zA-Z][0-9][0-9]|[a-zA-Z][0-9][a-zA-Z]|[a-zA-Z][a-zA-Z][0-9][a-zA-Z]) ([0-9][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ])", ErrorMessage = _locationError)]
        public string Location { get; set; }
        public bool LocationHasError { get; set; }
        public string LocationError => _locationError;

        public RadiusDistance LocationRadius { get; set; }
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
