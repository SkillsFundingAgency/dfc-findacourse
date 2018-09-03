using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum SortBy
    {
        Relevance = 0,
        Distance = 1,
        [Display(Name = "Start Date")]
        StartDate = 2
    }
}