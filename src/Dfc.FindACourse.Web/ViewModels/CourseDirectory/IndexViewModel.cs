using Dfc.FindACourse.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.ViewModels.CourseDirectory
{
    public class IndexViewModel
    {
        private const string _locationError = "Enter a full and valid postcode";
        private const string _subjectKeywordError = "Course name or subject contains invalid characters.";

        public RadiusDistance DefaultRadiusDistance => RadiusDistance.Miles10;

        [Display(Name = "Course name")]
        [Required(ErrorMessage = "Enter a course name")]
        [RegularExpression(@"^[a-zA-Z0-9& ()\\\+-:',\./]*$", ErrorMessage = _subjectKeywordError)]
        public string SubjectKeyword { get; set; }
        [Display(Name = "Postcode")]
        [RegularExpression(@"([a-zA-Z][0-9]|[a-zA-Z][0-9][0-9]|[a-zA-Z][a-zA-Z][0-9]|[a-zA-Z][a-zA-Z][0-9][0-9]|[a-zA-Z][0-9][a-zA-Z]|[a-zA-Z][a-zA-Z][0-9][a-zA-Z]) ([0-9][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ])", ErrorMessage = _locationError)]
        public string Location { get; set; }
        public List<SelectListItem> QualificationLevels { get; set; }
        public bool LocationHasError { get; set; }
        public string LocationError => _locationError;
    }
}
