using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;

namespace Dfc.FindACourse.Web.Interfaces
{
    public interface ITelemetryClient
    {
        
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        void Flush();

        void TrackException(Exception exception, IDictionary<string, string> properties = null,
            IDictionary<string, double> metrics = null);
    }


    // This Class is a wrapper class to allow DI and mocking. 
    // It simply passes on the call to the real object.
    // This class does not require Unit Testing.
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