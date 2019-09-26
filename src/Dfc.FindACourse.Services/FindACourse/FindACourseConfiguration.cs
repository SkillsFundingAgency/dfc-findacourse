using Dfc.FindACourse.Services.Interfaces;
using System;

namespace Dfc.FindACourse.Services.FindACourse
{
    public class FindACourseConfiguration: IFindACourseConfiguration
    {

        public string ApiKey { get; }
        public int PerPage { get; }
        public string ApiAddress { get; }
        public string UserName { get; }
        public string Password { get; }

        public FindACourseConfiguration(string apiKey, int perPage, string apiAddress, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException($"{nameof(apiKey)} cannot be null, empty or only whitespace.");
            if (perPage <= 0)
                throw new ArgumentOutOfRangeException(nameof(perPage));
            if (string.IsNullOrWhiteSpace(apiAddress))
                throw new ArgumentException($"{nameof(apiKey)} cannot be null, empty or only whitespace.");
            ApiKey = apiKey;
            PerPage = perPage;
            ApiAddress = apiAddress;
            UserName = userName;
            Password = password;
        }
    }
}
