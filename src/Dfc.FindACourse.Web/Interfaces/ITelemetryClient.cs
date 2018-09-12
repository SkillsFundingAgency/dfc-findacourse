using System;
using System.Collections.Generic;

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
}