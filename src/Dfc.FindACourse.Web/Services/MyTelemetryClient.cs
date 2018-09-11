using System;
using System.Collections.Generic;
using Dfc.FindACourse.Web.Interfaces;
using Microsoft.ApplicationInsights;

namespace Dfc.FindACourse.Web.Services
{
    public class MyTelemetryClient : ITelemetryClient
    {
        public TelemetryClient TelemetryClient { get; }

        public MyTelemetryClient(TelemetryClient telemetryClient)
        {
            TelemetryClient = telemetryClient;
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            TelemetryClient.TrackEvent(eventName, properties, metrics);
        }

        public void Flush()
        {
            TelemetryClient.Flush();
        }

        public void TrackException(Exception exception, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            TelemetryClient.TrackException(exception, properties, metrics);
        }
    }
}