using Dfc.FindACourse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Services.Postcode
{
    public class PostcodeServiceConfiguration : IPostcodeServiceConfiguration
    {
        public string ApiBaseUrl { get; }

        public PostcodeServiceConfiguration(string apiBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(apiBaseUrl))
                throw new ArgumentException($"{nameof(apiBaseUrl)} cannot be null, empty or only whitespace.");

            ApiBaseUrl = apiBaseUrl;
        }
    }
}
