using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Settings;
using Dfc.FindACourse.Services.Interfaces;
using Dfc.FindACourse.Web.Interfaces;
using Dfc.FindACourse.Web.Middleware;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class BaseTests
    {
        

        private Mock<IConfiguration> _configMock;
        public Mock<IConfiguration> MockConfiguration
        {
            get
            {
                if (_configMock != null) return _configMock;

                var mock = new Mock<IConfiguration>();
               // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _configMock = mock;
                return _configMock;
            }
        }

        private Mock<ICourseDirectoryService> _courseDirectoryServiceMock;
        public Mock<ICourseDirectoryService> MockCourseDirectoryService
        {
            get
            {
                if (_courseDirectoryServiceMock != null) return _courseDirectoryServiceMock;

                var mock = new Mock<ICourseDirectoryService>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _courseDirectoryServiceMock = mock;
                return _courseDirectoryServiceMock;
            }
        }

        private Mock<IMemoryCache> _memoryCacheMock;
        public Mock<IMemoryCache> MockMemoryCache
        {
            get
            {
                if (_memoryCacheMock != null) return _memoryCacheMock;

                var mock = new Mock<IMemoryCache>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _memoryCacheMock = mock;
                return _memoryCacheMock;
            }
        }

        private Mock<ITelemetryClient> _telemetryClientMock;
        public Mock<ITelemetryClient> MockTelemetryClient
        {
            get
            {
                if (_telemetryClientMock != null) return _telemetryClientMock;

                var mock = new Mock<ITelemetryClient>();
                _telemetryClientMock = mock;
                return _telemetryClientMock;
            }
        }

        private Mock<IOptions<App>> _appSettingsMock;
        public Mock<IOptions<App>> MockAppSettings
        {
            get
            {
                if (_appSettingsMock != null) return _appSettingsMock;

                var mock = new Mock<IOptions<App>>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _appSettingsMock = mock;
                return _appSettingsMock;
            }
        }

        private Mock<ICourseDirectory> _courseDirectoryMock;
        public Mock<ICourseDirectory> MockCourseDirectory
        {
            get
            {
                if (_courseDirectoryMock != null) return _courseDirectoryMock;

                var mock = new Mock<ICourseDirectory>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _courseDirectoryMock = mock;
                return _courseDirectoryMock;
            }
        }

        private Mock<IFileHelper> _fileHelperMock;
        public Mock<IFileHelper> MockFileHelper
        {
            get
            {
                if (_fileHelperMock != null) return _fileHelperMock;

                var mock = new Mock<IFileHelper>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _fileHelperMock = mock;
                return _fileHelperMock;
            }
        }

        private Mock<ICourseDirectoryHelper> _courseDirectoryHelper;
        public Mock<ICourseDirectoryHelper> MockCourseDirectoryHelper
        {
            get
            {
                if (_courseDirectoryHelper != null) return _courseDirectoryHelper;

                var mock = new Mock<ICourseDirectoryHelper>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _courseDirectoryHelper = mock;
                return _courseDirectoryHelper;
            }
        }

        private Mock<IPostcodeService> _postcodeService;
        public Mock<IPostcodeService> MockPostcodeService
        {
            get
            {
                if (_postcodeService != null) return _postcodeService;

                var mock = new Mock<IPostcodeService>();
                // mock.Setup(x => x.GetAll()).Returns(StoriesAll);
                _postcodeService = mock;
                return _postcodeService;
            }
        }

        private Mock<ICorrelationContextAccessor> _correlationContextAccessor;
        public Mock<ICorrelationContextAccessor> MockCorrelationContextAccessor
        {
            get
            {
                if (_correlationContextAccessor != null) return _correlationContextAccessor;

                var mockContext = new Mock<ICorrelationContext>();
                mockContext.SetupGet(x => x.CorrelationId).Returns(Guid.NewGuid().ToString);
                mockContext.SetupGet(x => x.Header).Returns(new CorrelationIdOptions().Header);

                var mock = new Mock<ICorrelationContextAccessor>();
                mock.SetupGet(x => x.CorrelationContext).Returns(mockContext.Object);
                _correlationContextAccessor = mock;
                return _correlationContextAccessor;
            }
        }
    }
}