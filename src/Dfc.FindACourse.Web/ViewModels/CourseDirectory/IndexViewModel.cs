﻿using Dfc.FindACourse.Common;
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
        public RadiusDistance DefaultRadiusDistance => RadiusDistance.Miles10;

        [Display(Name = "Course name")]
        [Required(ErrorMessage = "Enter a course name")]
        public string SubjectKeyword { get; set; }
        [Display(Name = "Postcode")]
        [RegularExpression(@"([a-zA-Z][0-9]|[a-zA-Z][0-9][0-9]|[a-zA-Z][a-zA-Z][0-9]|[a-zA-Z][a-zA-Z][0-9][0-9]|[a-zA-Z][0-9][a-zA-Z]|[a-zA-Z][a-zA-Z][0-9][a-zA-Z]) ([0-9][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ][abdefghjklmnpqrstuwxyzABDEFGHJLMNPQRSTUWXYZ])", ErrorMessage = "Invalid postcode")]
        public string Location { get; set; }
        public List<SelectListItem> QualificationLevels { get; set; }
        public bool LocationHasError => !string.IsNullOrWhiteSpace(LocationError);
        public string LocationError { get; set; }
    }
}
