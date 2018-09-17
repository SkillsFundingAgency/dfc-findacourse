using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;

namespace Dfc.FindACourse.Services.Interfaces
{
    public interface ICourseDirectoryService
    {
        IResult<CourseSearchResult> CourseSearch(ICourseSearchCriteria criteria, IPagingOptions options);

        //According to the stub this result set contains
        // CourseDetailRequestStructure and CourseDetailStructure
        //
        //CourseDetailStructure contains
        //  ProviderDetail
        //  CourseDetail
        //  OpportunityDetail
        //  VenueDetail
        //  
        //  
        //  
        //  

        IResult<CourseItemDetail> CourseItemDetail(int? courseDetailsId, int? opportunityId);
    }
}