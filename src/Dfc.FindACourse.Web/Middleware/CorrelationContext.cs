using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Middleware
{
    public class CorrelationContext
    {
        internal CorrelationContext(string correlationId, string header)
        {
            if (string.IsNullOrWhiteSpace(correlationId))
                throw new ArgumentNullException(nameof(correlationId));

            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentNullException(nameof(header));

            CorrelationId = correlationId;
            Header = header;
        }

        public string CorrelationId { get; }
        public string Header { get; }
    }
}
