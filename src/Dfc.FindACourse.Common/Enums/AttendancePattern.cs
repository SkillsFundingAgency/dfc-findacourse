using System.ComponentModel.DataAnnotations;
namespace Dfc.FindACourse.Common
{
    public enum AttendancePattern
    {
        [Display(Name = "Not Known")]
        NotKnown = 0,
        [Display(Name = "Normal Working Hours")]
        DaytimeWorkHours = 1,
        [Display(Name = "Day Release/Block Release")]
        DayBlockRelease = 2,
        [Display(Name = "Evening/Weekend")]
        Evening = 3,
        [Display(Name = "Evening/Weekend")]
        Twilight = 4,
        [Display(Name = "Evening/Weekend")]
        Weekend = 5,
        [Display(Name = "Customised")]
        Customised = 6,
        [Display(Name = "Not Applicable")]
        NotApplicable = 7
    }
}