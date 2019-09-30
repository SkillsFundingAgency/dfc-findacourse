using Dfc.FindACourse.Common;
using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Common.Models.FindACourse;
using Dfc.FindACourse.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Services.FindACourse
{
    public class FindACourseService
    {
        public IFindACourseConfiguration Configuration { get; }
        public ICourseAPIConfiguration  CourseAPIConfig{ get; }

        public FindACourseService(IFindACourseConfiguration configuration, ICourseAPIConfiguration courseapiconfig)
        {
            Configuration = configuration;
            CourseAPIConfig = courseapiconfig;
        }

        public async Task<IResult<Common.Models.FindACourse.FindACourseSearchResult>> FindACourseSearch(ICourseSearchCriteria criteria, IPagingOptions options)
        {
            //Bypass current SSL Expiry
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            var client = new HttpClient(clientHandler);
            
            criteria.TopResults = Configuration.PerPage;
            criteria.PageNo = options.PageNo;
            //criteria.QualificationLevels = GetQualLevels(criteria.QualificationLevels):
            //criteria.TownOrPostcode = "b44 9ud";
            criteria.Distance = 100;
                       
            StringContent content = new StringContent(JsonConvert.SerializeObject(criteria), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Configuration.ApiKey);
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("UserName", Configuration.UserName);
            client.DefaultRequestHeaders.Add("Password", Configuration.Password);

           
            var response = await client.PostAsync($"{Configuration.ApiAddress}/coursesearch", content);

            var jsonResult = await response.Content.ReadAsStringAsync();

            // Return data as model object
            //return Result.Ok(JsonConvert.DeserializeObject<Common.Models.FindACourse.FindACourseSearchResult>(jsonResult));
            return CreateFindACourseSearchResult(jsonResult, options, Configuration.PerPage);


        }

        public IResult<Common.Models.FindACourse.FindACourseSearchResult> CreateFindACourseSearchResult(string response, IPagingOptions options, int? itemsperpage)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            if (string.IsNullOrEmpty(response))
            {
                return Result.Ok(new FindACourseSearchResult("", 0, 0, new FindACourseSearchItem[] { }));
            }


            var searchResult = JsonConvert.DeserializeObject<FindACourseSearchResult>(response);
            searchResult.PageNo = options.PageNo;
            ///need to get total courses, divide by items per page, and get a NoOfPages count
            searchResult.NoOfPages = searchResult.ODataCount % itemsperpage == 0 ? searchResult.ODataCount.Value / itemsperpage.Value : (searchResult.ODataCount / itemsperpage) + 1;

            return Result.Ok(searchResult);

        }
        //internal string[] GetQualLevels(List<QualLevel> QualificationLevels)
        //{
        //    //string[] quals = new string[1];

        //    return QualificationLevels.Select(x => x.Key).ToArray<string>();
        //}
        public async Task<IResult<FindACourseDetail>> CourseGet(string courseId, string runId)
        {
            //Bypass current SSL Expiry
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Call service to get data
            var client = new HttpClient();
            //denbug
            courseId = "657fb015-3ef6-47b7-af86-6ee761e688ce";
            runId = "f79fdd88-2a7a-4856-959f-61b4ab036c1f";
            var criteria = new FindACourseGetCriteria(courseId, runId);


            //string urliii = $"{CourseAPIConfig.ApiAddress}/GetCourseById?id=" + courseId;
            StringContent content = new StringContent(JsonConvert.SerializeObject(criteria), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Configuration.ApiKey);
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("UserName", Configuration.UserName);
            client.DefaultRequestHeaders.Add("Password", Configuration.Password);

            //var response = await client.GetAsync(urliii);
            var response = await client.PostAsync($"{Configuration.ApiAddress}/courseget", content);

            var jsonResult = await response.Content.ReadAsStringAsync();

            //// Return data as model object
            ////return Result.Ok(JsonConvert.DeserializeObject<Common.Models.FindACourse.FindACourseSearchResult>(jsonResult));
            //return CreateFindACourseCourseResult(jsonResult, options, Configuration.PerPage);

            return CreateFindACourseDetailResult(jsonResult);
        }
        public async Task<IResult<FindACourseDetail>> CourseGet(string courseId)
        {
            //Bypass current SSL Expiry
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Call service to get data
            HttpClient client = new HttpClient();

            // StringContent content = new StringContent(JsonConvert.SerializeObject(criteria), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", CourseAPIConfig.ApiKey);

            string urliii = $"{CourseAPIConfig.ApiAddress}/GetCourseById?id=" + courseId;

            var response = await client.GetAsync(urliii);

            var jsonResult = await response.Content.ReadAsStringAsync();

            //// Return data as model object
            ////return Result.Ok(JsonConvert.DeserializeObject<Common.Models.FindACourse.FindACourseSearchResult>(jsonResult));
            //return CreateFindACourseCourseResult(jsonResult, options, Configuration.PerPage);

            return CreateFindACourseDetailResult(jsonResult);
        }

        public IResult<FindACourseDetail> CreateFindACourseDetailResult(string response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            //if (string.IsNullOrEmpty(response))
            //{
            //    return Result.Ok(new FindACourseDetail("", 0, 0, new IFindACourseRun[] { }));
            //}


            var searchResult = JsonConvert.DeserializeObject<FindACourseDetail>(response);
           
            return Result.Ok(searchResult);

        }
    }
}
