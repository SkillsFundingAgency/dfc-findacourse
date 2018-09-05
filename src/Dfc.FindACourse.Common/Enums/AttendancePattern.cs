using System.ComponentModel.DataAnnotations;
namespace Dfc.FindACourse.Common
{
    public enum AttendancePattern
    {
        [Display(Name = "Not Known")]
        NotKnown = 0,
        [Display(Name = "Daytime Work Hours")]
        DaytimeWorkHours = 1,
        [Display(Name = "Day Block Release")]
        DayBlockRelease = 2,

        Evening = 3,
        Twilight = 4,
        Weekend = 5,
        Customised = 6,
        [Display(Name = "Not Applicable")]
        NotApplicable = 7
    }
}