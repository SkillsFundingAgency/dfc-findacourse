using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Middleware
{
    public interface ICorrelationContextFactory
    {
        CorrelationContext Create(string correlationId, string header);
        void Dispose();
    }
}
