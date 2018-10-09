namespace Dfc.FindACourse.Web.Middleware
{
    public interface ICorrelationContext
    {
        string CorrelationId { get; }
        string Header { get; }
    }
}