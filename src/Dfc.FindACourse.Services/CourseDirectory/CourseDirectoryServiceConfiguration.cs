using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseDirectoryServiceConfiguration : ICourseDirectoryServiceConfiguration
    {
        public string ApiKey { get; }

        public CourseDirectoryServiceConfiguration(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException($"{nameof(apiKey)} cannot be null, empty or only whitespace.");

            ApiKey = apiKey;
        }
    }
}
