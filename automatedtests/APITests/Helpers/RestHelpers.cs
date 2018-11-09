namespace APITests.Helpers
{
    using RestSharp;

    public class RestHelpers
    {
        public RestClient endpoint = null;

        public RestClient SetEndpoint(string endpointUrl)
        {
            endpoint = new RestClient(endpointUrl);
            return endpoint;
        }

        public string GetQuery(string query)
        {
            var request = new RestRequest(query, Method.GET);
            IRestResponse response = endpoint.Execute(request);
            var content = response.Content; 
            return content;
        }

        public void UpdateCourseDescription(string query, string courseDesc)
        {
            var request = new RestRequest(query, Method.POST) { RequestFormat = DataFormat.Xml };
            var body = ("<resource><CourseDescription>" + courseDesc + "</CourseDescription></resource>");
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            endpoint.Execute(request);
        }

        public void DeleteQuery(string query)
        {
            var request = new RestRequest(query, Method.DELETE);
            endpoint.Execute(request);
        }
    }
}