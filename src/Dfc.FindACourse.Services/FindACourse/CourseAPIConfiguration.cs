using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.FindACourse
{
    public class CourseAPIConfiguration: ICourseAPIConfiguration
    {
        public string ApiKey { get; }
        public string ApiAddress { get; }

        public CourseAPIConfiguration(string apikey, string apiaddress)
        {
            ApiKey = apikey;
            ApiAddress = apiaddress;

        }
    }
}
