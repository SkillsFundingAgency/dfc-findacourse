using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dfc.FindACourse.Common
{
    public enum ApplicationAcceptedThroughoutYear
    {
        [Display(Name = "Yes")]
        Y = 0,
        [Display(Name = "No")]
        N = 1

    }
}
