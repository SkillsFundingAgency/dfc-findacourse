using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dfc.FindACourse.Common
{
    public enum RadiusDistance
    {
        [Display(Name = "1 Mile")]
        Miles1 = 1,

        [Display(Name = "3 Miles")]
        Miles3 = 3,

        [Display(Name = "5 Miles")]
        Miles5 = 5,

        [Display(Name = "10 Miles")]
        Miles10 = 10,

        [Display(Name = "15 Miles")]
        Miles15 = 15,

        [Display(Name = "20 Miles")]
        Miles20 = 20,

        [Display(Name = "National")]
        National = 1000
    }
}
