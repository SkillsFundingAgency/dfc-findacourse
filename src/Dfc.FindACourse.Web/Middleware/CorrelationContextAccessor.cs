﻿using System.Threading;

namespace Dfc.FindACourse.Web.Middleware
{
    public class CorrelationContextAccessor : ICorrelationContextAccessor
    {
        private static AsyncLocal<CorrelationContext> _correlationContext = new AsyncLocal<CorrelationContext>();

        public CorrelationContext CorrelationContext
        {
            get => _correlationContext.Value;
            set => _correlationContext.Value = value;
        }
    }
}
