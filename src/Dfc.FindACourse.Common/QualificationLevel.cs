using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum QualificationLevel
    {
        [Display(Name = "Entry level - Skills for Life")]
        EntryLevel = 0,

        [Display(Name = "Level 1 - First certificate")]
        Level1 = 1,

        [Display(Name = "Level 2 - GCSE/O level")]
        Level2 = 2,

        [Display(Name = "Level 3 - A level/Access to higher education diploma")]
        Level3 = 3,

        [Display(Name = "Level 4 - Certificate of higher education/HNC")]
        Level4 = 4,

        [Display(Name = "Level 5 - Foundation degree/HND")]
        Level5 = 5,
    
        [Display(Name = "Level 6 - Degree/Graduate diploma")]
        Level6 = 6,

        [Display(Name = "Level 7 - Masters Degree/Postgraduate diploma")]
        Level7 = 7,
    
        [Display(Name = "Level 8 - Doctorate/PhD")]
        Level8 = 8,

        [Display(Name = "Higher Level")]
        Level9 = 9,

        [Display(Name = "Unknown/not applicable")]
        LevelNa = 10,
    }
}