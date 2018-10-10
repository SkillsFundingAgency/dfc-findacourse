using Microsoft.Extensions.DependencyInjection;

namespace Dfc.FindACourse.Web.Middleware
{
    public static class CorrelationIdServiceExtensions
    {
        public static IServiceCollection AddCorrelationId(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICorrelationContextAccessor, CorrelationContextAccessor>();
            serviceCollection.AddTransient<ICorrelationContextFactory, CorrelationContextFactory>();

            return serviceCollection;
        }
    }
}
