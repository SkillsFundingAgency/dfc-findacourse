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
        public RadiusDistance DefaultRadiusDistance => RadiusDistance.Miles10;

        [Display(Name = "Course name")]
        [Required]
        public string SubjectKeyword { get; set; }
        public IEnumerable<SelectListItem> QualificationLevels { get; set; }

    }
}
