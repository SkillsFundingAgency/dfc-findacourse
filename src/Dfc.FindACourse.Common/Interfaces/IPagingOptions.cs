namespace Dfc.FindACourse.Common.Interfaces
{
    public interface IPagingOptions
    {
        SortBy SortBy { get; }
        int PageNo { get; }
    }
}