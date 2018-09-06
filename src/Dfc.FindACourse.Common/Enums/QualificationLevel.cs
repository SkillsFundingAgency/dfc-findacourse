using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum QualificationLevel
    {
        [Display(Name = "Entry level")]
        EntryLevel = 0,

        [Display(Name = "Level 1")]
        Level1 = 1,

        [Display(Name = "Level 2")]
        Level2 = 2,

        [Display(Name = "Level 3")]
        Level3 = 3,

        [Display(Name = "Level 4")]
        Level4 = 4,

        [Display(Name = "Level 5")]
        Level5 = 5,
    
        [Display(Name = "Level 6")]
        Level6 = 6,

        [Display(Name = "Level 7")]
        Level7 = 7,
    
        [Display(Name = "Level 8")]
        Level8 = 8,

        [Display(Name = "Unknown")]
        Level9 = 9,

        [Display(Name = "")]
        LevelNa = 10,
    }
}