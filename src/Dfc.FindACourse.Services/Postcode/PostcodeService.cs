using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Services.Postcode
{
    public class PostcodeService : IPostcodeService
    {
        private IPostcodeServiceConfiguration _configuration;
        private HttpClient _client;

        public PostcodeService(IPostcodeServiceConfiguration configuration, HttpClientHandler clientHandler)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if (clientHandler == null)
                throw new ArgumentNullException(nameof(clientHandler));

            _configuration = configuration;
            _client = new HttpClient(clientHandler, false);
        }

        public async Task<IResult<bool>> IsValidAsync(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode))
                return Result.Fail<bool>($"{postcode} cannot be null, empty or only whitespace.");

            try
            {
                var url = $"{_configuration.ApiBaseUrl}/postcodes/{postcode}/validate";
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = _client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    
                    if (content == "{\"status\":200,\"result\":true}")
                    {
                        return Result.Ok(true);
                    }
                    else
                    {
                        return Result.Fail<bool>("Invalid postcode.");
                    }
                }
                else
                {
                    return Result.Fail<bool>("Unsuccessful response.");
                }
            }
            catch (Exception e)
            {
                return Result.Fail<bool>(e.Message);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
