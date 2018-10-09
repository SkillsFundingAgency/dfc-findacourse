using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CorrelationIdOptions _options;

        public CorrelationIdMiddleware(RequestDelegate next, IOptions<CorrelationIdOptions> options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task Invoke(HttpContext context, ICorrelationContextFactory correlationContextFactory)
        {
            var correlationId = SetCorrelationId(context);

            if (_options.UpdateTraceIdentifier)
                context.TraceIdentifier = correlationId;

            correlationContextFactory.Create(correlationId, _options.Header);

            if (_options.IncludeInResponse)
            {
                // apply the correlation ID to the response header for client side tracking
                context.Response.OnStarting(() =>
                {
                    if (!context.Response.Headers.ContainsKey(_options.Header))
                    {
                        context.Response.Headers.Add(_options.Header, correlationId);
                    }

                    if (!context.Request.Cookies.ContainsKey(_options.Header))
                    {
                        context.Response.Cookies.Append(_options.Header, correlationId);
                    }

                    return Task.CompletedTask;
                });
            }

            await _next(context);

            correlationContextFactory.Dispose();
        }

        private StringValues SetCorrelationId(HttpContext context)
        {
            var correlationIdFoundInRequestCookie = context.Request.Cookies.TryGetValue(_options.Header, out var correlationId);

            if (RequiresGenerationOfCorrelationId(correlationIdFoundInRequestCookie, correlationId))
                correlationId = GenerateCorrelationId(context.TraceIdentifier);


            return correlationId;
        }

        private static bool RequiresGenerationOfCorrelationId(bool idInHeader, StringValues idFromHeader) =>
            !idInHeader || StringValues.IsNullOrEmpty(idFromHeader);

        private StringValues GenerateCorrelationId(string traceIdentifier) =>
            _options.UseGuidForCorrelationId || string.IsNullOrEmpty(traceIdentifier) ? Guid.NewGuid().ToString() : traceIdentifier;
    }
}
