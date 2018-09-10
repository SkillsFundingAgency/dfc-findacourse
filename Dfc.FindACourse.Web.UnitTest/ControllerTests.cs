using System.Collections.Generic;
using Dfc.FindACourse.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Dfc.FindACourse.Web.UnitTest
{
    [TestClass]
    public class ControllerTests : BaseTests
    {
        public CourseDirectoryController Controller { get; private set; }

        [TestInitialize]
        public void Init()
        {
            BuildController();
        }

        public void BuildController()
        {
            Controller = new CourseDirectoryController
            (
                MockConfiguration.Object,
                MockCourseDirectoryService.Object,
                MockMemoryCache.Object,
                MockTelemetryClient.Object,
                MockAppSettings.Object,
                MockDataService.Object,
                MockFileHelper.Object
            );
            Assert.IsNotNull(Controller.Configuration, "Configuration");
            Assert.IsNotNull(Controller.Service, "Service");
            Assert.IsNotNull(Controller.Cache, "Cache");
            Assert.IsNotNull(Controller.Telemetry, "Telemetry");
            Assert.IsNotNull(Controller.Settings, "Settings");
            Assert.IsNotNull(Controller.Files, "Settings");
            Assert.IsNotNull(Controller.CourseDirectory);
        }

        [TestMethod]
        public void TestConstruction()
        {
            BuildController();
        }

        // Tests the Starting View.
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            MockDataService.Setup(x => x.GetQualificationLevels()).Returns(new List<SelectListItem>()).Verifiable();
            MockTelemetryClient.Setup(x=>x.TrackEvent(It.IsAny<string>(), null, null)).Verifiable();

            // Act
            var result = Controller.Index();

            // Assert
            MockDataService.Verify();
            MockTelemetryClient.Verify();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAutocomplete()
        {
            throw new AssertFailedException();
            //Arrange
            var inp =
                "[[\"ANIMAL\",\"ANIMAL BEHAVIOUR\",\"ANIMAL KEEPER\",\"ANIMAL CARE\",\"ANIMAL MANAGEMENT\",\"ANIMAL WELFARE\",\"ANIMALS\"]]";
            var input = JsonConvert.DeserializeObject<List<string>>(inp);

            //var input = new JsonResult(list);
            
           // MockDataService.Setup(x=>x.AutoSuggestCourseName(It.IsAny<string>())).Returns

            //Act

            //Assert that the Returned List is 
            //1) Ordered Descending by groups
            //2) Items in Groups are ordered - Not ure if this is correct interpretation
            //3) List only has distinct items
            //4) It is of type list
            // got expected Json

        }


        [TestMethod]
        public void TestCourseSearchResult()
        {
            throw new AssertFailedException();
        }
    }
}
