using Dfc.FindACourse.Services.Interfaces;
using System;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseDirectoryServiceConfiguration : ICourseDirectoryServiceConfiguration
    {
        public string ApiKey { get; }
        public int PerPage { get; }

        public CourseDirectoryServiceConfiguration(string apiKey, int perPage)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException($"{nameof(apiKey)} cannot be null, empty or only whitespace.");
            if (perPage <= 0)
                throw new ArgumentOutOfRangeException(nameof(perPage));

            ApiKey = apiKey;
            PerPage = perPage;
        }
    }
}