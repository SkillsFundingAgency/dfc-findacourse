using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dfc.FindACourse.Common
{
    public enum RadiusDistance
    {
        [Display(Name = "1 Mile")]
        Miles1 = 0,

        [Display(Name = "3 Miles")]
        Miles3 = 1,

        [Display(Name = "5 Miles")]
        Miles5 = 2,

        [Display(Name = "10 Miles")]
        Miles10 = 3,

        [Display(Name = "15 Miles")]
        Miles15 = 4,

        [Display(Name = "20 Miles")]
        Miles20 = 5,

        [Display(Name = "National")]
        National = 1000
    }
}
