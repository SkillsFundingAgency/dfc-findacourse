using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Middleware
{
    public class CorrelationContextFactory : ICorrelationContextFactory
    {
        private readonly ICorrelationContextAccessor _correlationContextAccessor;

        public CorrelationContextFactory() : this(null) { }

        public CorrelationContextFactory(ICorrelationContextAccessor correlationContextAccessor)
        {
            _correlationContextAccessor = correlationContextAccessor;
        }

        public CorrelationContext Create(string correlationId, string header)
        {
            var correlationContext = new CorrelationContext(correlationId, header);

            if (_correlationContextAccessor != null)
                _correlationContextAccessor.CorrelationContext = correlationContext;

            return correlationContext;
        }

        public void Dispose()
        {
            if (_correlationContextAccessor != null)
                _correlationContextAccessor.CorrelationContext = null;
        }
    }
}
