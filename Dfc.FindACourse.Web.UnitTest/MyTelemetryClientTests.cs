using System;
using System.Collections.Generic;
using Dfc.FindACourse.TestUtilities.TestUtilities;
using Dfc.FindACourse.Web.Services;
using Microsoft.ApplicationInsights;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dfc.FindACourse.Web.UnitTest
{
    [TestClass]
    public class MyTelemetryClientTests
    {
        private MyTelemetryClient Service { get; set; }

        [TestInitialize]
        public void Init()
        {
            BuildServiceClass();
        }

        public void BuildServiceClass()
        {
            Service = new MyTelemetryClient(new TelemetryClient());

            Assert.IsNotNull(Service.TelemetryClient);
        }

        [TestMethod]
        public void TestConstruction()
        {
            BuildServiceClass();
        }

        [TestMethod]
        public void TestTrackEvent()
        {
            Service.TrackEvent("test");
            var properties = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            var metrics = new Dictionary<string, double> {{"key3", 3}, {"key4", 4}};
            Service.TrackEvent("test1", properties);
            Service.TrackEvent("test1", null, metrics);
            Service.TrackEvent("test1", properties, metrics);
        }

        [TestMethod]
        public void TestFlush()
        {
            Service.Flush();
        }

        [TestMethod]
        public void TestTrackException()
        {
            var ex = new Exception("test");
            var properties = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };
            var metrics = new Dictionary<string, double> { { "key3", 3 }, { "key4", 4 } };
            Service.TrackException(ex, properties);
            Service.TrackException(ex, null, metrics);
            Service.TrackException(ex, properties, metrics);
        }
    }
}
