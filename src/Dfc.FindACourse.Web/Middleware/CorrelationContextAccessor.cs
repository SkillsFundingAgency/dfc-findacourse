using System.Threading;

namespace Dfc.FindACourse.Web.Middleware
{
    public class CorrelationContextAccessor : ICorrelationContextAccessor
    {
        private static AsyncLocal<ICorrelationContext> _correlationContext = new AsyncLocal<ICorrelationContext>();

        public ICorrelationContext CorrelationContext
        {
            get => _correlationContext.Value;
            set => _correlationContext.Value = value;
        }
    }
}
