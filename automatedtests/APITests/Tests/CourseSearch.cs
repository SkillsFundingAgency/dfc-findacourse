using NUnit.Framework;
using System;


namespace APITests.Tests
{
    class CourseSearch
    {

        CourseSearchService.CourseDetailRequestStructure _service = new CourseSearchService.CourseDetailRequestStructure();

       // [Test]
        [Ignore("Ignored test")]
        public void GetCourseDetails()
        {
            var x = _service.CourseID;
            var y = _service.APIKey;

           Console.WriteLine ( _service.ToString().ToLower());

        }
    }
}