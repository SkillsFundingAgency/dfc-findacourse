namespace Dfc.FindACourse.Web.Middleware
{
    public interface ICorrelationContextAccessor
    {
        ICorrelationContext CorrelationContext { get; set; }
    }
}
