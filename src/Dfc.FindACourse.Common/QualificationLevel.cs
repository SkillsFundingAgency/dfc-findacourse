using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum QualificationLevel
    {
        [Display(Name = "Please select")]
        LevelNa = 0,

        [Display(Name = "Entry level - Skills for Life")]
        EntryLevel = 1,

        [Display(Name = "Level 1 - First certificate")]
        Level1 = 2,

        [Display(Name = "Level 2 - GCSE/O level")]
        Level2 = 3,

        [Display(Name = "Level 3 - A level/Access to higher education diploma")]
        Level3 = 4,

        [Display(Name = "Level 4 - Certificate of higher education/HNC")]
        Level4 = 5,

        [Display(Name = "Level 5 - Foundation degree/HND")]
        Level5 = 6,

        [Display(Name = "Level 6 - Degree/Graduate diploma")]
        Level6 = 7,

        [Display(Name = "Level 7 - Masters Degree/Postgraduate diploma")]
        Level7 = 8,

        [Display(Name = "Level 8 - Doctorate/PhD")]
        Level8 = 9,
    }
}