using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Middleware
{
    public interface ICorrelationIdOptions
    {
        string Header { get; }
        bool IncludeInResponse { get; }
        bool UpdateTraceIdentifier { get; }
        bool UseGuidForCorrelationId { get; }
    }
}
