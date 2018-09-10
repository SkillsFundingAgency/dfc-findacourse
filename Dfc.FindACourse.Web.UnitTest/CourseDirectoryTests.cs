using Dfc.FindACourse.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dfc.FindACourse.Web.UnitTest
{
    [TestClass]
    public class CourseDirectoryTests : BaseTests
    {
        private CourseDirectory ServiceClass { get; set; }

        [TestInitialize]
        public void Init()
        {
            BuildServiceClass();
        }

        public void BuildServiceClass()
        {
            ServiceClass = new CourseDirectory(MockFileHelper.Object);

            Assert.IsNotNull(ServiceClass.Files);
        }

        [TestMethod]
        public void TestConstruction()
        {
            BuildServiceClass();
        }

        [TestMethod]
        public void TestGetQualificationLevels()
        {
          //  throw new AssertFailedException();
        }

        [TestMethod]
        public void TestAutoSuggestCourseName()
        {
         //   throw new AssertFailedException();

        }
    }
}
