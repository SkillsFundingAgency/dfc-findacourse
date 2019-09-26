using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.FindACourse
{
    public interface ICourseAPIConfiguration
    {
        string ApiKey { get; }
        string ApiAddress { get; }
    }
}
