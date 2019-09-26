
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dfc.FindACourse.Common.Models.FindACourse.Enums
{
    public enum DeliveryMode
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Classroom based")]
        ClassroomBased = 1,
        [Description("Online")]
        Online = 2,
        [Description("Work based")]
        WorkBased = 3
    }
    public enum DurationUnit
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Days")]
        Days = 1,
        [Description("Weeks")]
        Weeks = 2,
        [Description("Months")]
        Months = 3,
        [Description("Years")]
        Years = 4,
        [Description("Hours")]
        Hours = 5,
    }
    public enum StudyMode
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Full-time")]
        FullTime = 1,
        [Description("Part-time")]
        PartTime = 2,
        [Description("Flexible")]
        Flexible = 3
    }

    public enum AttendancePattern
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Daytime")]
        Daytime = 1,
        [Description("Evening")]
        Evening = 2,
        [Description("Weekend")]
        Weekend = 3,
        [Description("Day/Block Release")]
        DayOrBlockRelease = 4
    }
    public enum StartDateType
    {
        [Description("Defined Start Date")]
        SpecifiedStartDate = 1,
        [Description("Select a flexible start date")]
        FlexibleStartDate = 2,
    }
}
