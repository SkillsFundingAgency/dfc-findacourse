using Dfc.FindACourse.Common.Interfaces;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common
{
    public class TelemetryClientAdapter : ITelemetryClient
    {
        public TelemetryClient TelemetryClient { get; }

        public TelemetryClientAdapter(TelemetryClient telemetryClient)
        {
            TelemetryClient = telemetryClient;
        }

        public void TrackEvent(
            string eventName, 
            IDictionary<string, string> properties = null, 
            IDictionary<string, double> metrics = null)
        {
            TelemetryClient.TrackEvent(eventName, properties, metrics);
        }

        public void Flush()
        {
            TelemetryClient.Flush();
        }

        public void TrackException(
            Exception exception, 
            IDictionary<string, string> properties = null, 
            IDictionary<string, double> metrics = null)
        {
            TelemetryClient.TrackException(exception, properties, metrics);
        }
    }
}