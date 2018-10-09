namespace Dfc.FindACourse.Web.Middleware
{
    public interface ICorrelationContextAccessor
    {
        CorrelationContext CorrelationContext { get; set; }
    }
}
