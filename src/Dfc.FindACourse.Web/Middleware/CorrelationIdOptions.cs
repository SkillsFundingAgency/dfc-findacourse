using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Middleware
{
    public class CorrelationIdOptions
    {
        private const string DefaultHeader = "X-Correlation-ID";

        public string Header { get; set; } = DefaultHeader;
        public bool IncludeInResponse { get; set; } = true;
        public bool UpdateTraceIdentifier { get; set; } = true;
        public bool UseGuidForCorrelationId { get; set; } = false;
    }
}
