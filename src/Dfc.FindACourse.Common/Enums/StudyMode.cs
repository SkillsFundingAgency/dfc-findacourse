using System.ComponentModel.DataAnnotations;

namespace Dfc.FindACourse.Common
{
    public enum StudyMode
    {
        NotKnown = 0,

        [Display(Name = "Full Time")]
        FullTime = 1,

        [Display(Name = "Part Time")]
        PartTime = 2,

        PartTimeOfAFullTimeProgram = 3,

        [Display(Name = "Flexible")]
        Flexible = 4,
    }
}