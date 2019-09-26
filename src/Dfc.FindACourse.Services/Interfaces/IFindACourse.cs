using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Services.Interfaces
{
    interface IFindACourse
    {
        void CourseSearch();
        void CourseGet();

        void ProviderSearch();
        void ProviderGet();
    }
}
