using Dfc.FindACourse.Services.Interfaces;
using System;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class CourseDirectoryServiceConfiguration : ICourseDirectoryServiceConfiguration
    {
        public string ApiKey { get; }
        public int PerPage { get; }
        public string ApiAddress { get; }

        public CourseDirectoryServiceConfiguration(string apiKey, int perPage, string apiAddress)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException($"{nameof(apiKey)} cannot be null, empty or only whitespace.");
            if (perPage <= 0)
                throw new ArgumentOutOfRangeException(nameof(perPage));
            if(string.IsNullOrWhiteSpace(apiAddress))
                throw new ArgumentException($"{nameof(apiKey)} cannot be null, empty or only whitespace.");
            ApiKey = apiKey;
            PerPage = perPage;
            ApiAddress = apiAddress;
        }
    }
}