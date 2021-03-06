﻿using Dfc.FindACourse.Common;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using Xunit;

namespace Dfc.FindACourse.Web.xUnit.UnitTests
{
    public class TelemetryClientAdapterTests
    {
        private TelemetryClientAdapter Service { get; set; }
        public TelemetryClientAdapterTests()
        {
            Service = new TelemetryClientAdapter(new TelemetryClient());

            Assert.NotNull(Service.TelemetryClient);
        }

        [Fact]
        public void TestTrackEvent()
        {
            Service.TrackEvent("test");
            var properties = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };
            var metrics = new Dictionary<string, double> { { "key3", 3 }, { "key4", 4 } };
            Service.TrackEvent("test1", properties);
            Service.TrackEvent("test1", null, metrics);
            Service.TrackEvent("test1", properties, metrics);
        }

        [Fact]
        public void TestFlush()
        {
            Service.Flush();
        }

        [Fact]
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
