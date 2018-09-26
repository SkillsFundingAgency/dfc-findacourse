using System.ComponentModel.DataAnnotations;
namespace Dfc.FindACourse.Common
{
    public enum AttendancePattern
    {
        [Display(Name = "Not known")]
        NotKnown = 0,
        [Display(Name = "Normal working hours")]
        DaytimeWorkHours = 1,
        [Display(Name = "Day release/Block release")]
        DayBlockRelease = 2,
        [Display(Name = "Evening/Weekend")]
        Evening = 3,
        [Display(Name = "Evening/Weekend")]
        Twilight = 4,
        [Display(Name = "Evening/Weekend")]
        Weekend = 5,
        [Display(Name = "Customised")]
        Customised = 6,
        [Display(Name = "Not applicable")]
        NotApplicable = 7
    }
}