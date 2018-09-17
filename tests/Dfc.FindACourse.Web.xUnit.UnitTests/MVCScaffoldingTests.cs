using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class MvcScaffoldingTests
    {
        //[Fact]
        public void ConfigureServices_RegistersDependenciesCorrectly()
        {
            //  Arrange

            //  Setting up the stuff required for Configuration.GetConnectionString("DefaultConnection")
            /* Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();
             configurationSectionStub.Setup(x => x["DefaultConnection"]).Returns("TestConnectionString");
             Mock<Microsoft.Extensions.Configuration.IConfiguration> configurationStub = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
             configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);
             */
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = path.Replace("Dfc.FindACourse.Web.UnitTest\\bin\\Debug\\netcoreapp2.1", "src\\Dfc.FindACourse.Web");
            var mockHostingEnv = new Mock<IHostingEnvironment>();
            mockHostingEnv.Setup(x => x.ContentRootPath).Returns(path);
            mockHostingEnv.Setup(x => x.EnvironmentName).Returns("Development");

            IServiceCollection services = new ServiceCollection();
            var target = new Startup(mockHostingEnv.Object);

            //  Act
            target.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<TestController>();

            //  Assert

            var serviceProvider = services.BuildServiceProvider();

            var controller = serviceProvider.GetService<TestController>();
            Assert.NotNull(controller);
        }
    }




    public class TestController : Controller
    {
        public TestController()
        {
        }
    }
}
