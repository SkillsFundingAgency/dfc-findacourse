using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ITelemetryClient
    {
        void TrackEvent(
            string eventName, 
            IDictionary<string, string> properties = null, 
            IDictionary<string, double> metrics = null);

        void Flush();

        void TrackException(
            Exception exception, 
            IDictionary<string, string> properties = null,
            IDictionary<string, double> metrics = null);
    }
}