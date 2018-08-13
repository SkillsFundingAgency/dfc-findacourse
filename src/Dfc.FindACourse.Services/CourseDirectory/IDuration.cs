using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public interface IDuration
    {
        double Value { get; }
        string Unit { get; }
    }
}
