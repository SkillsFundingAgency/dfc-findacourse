using Dfc.FindACourse.Common.Interfaces;
using Dfc.FindACourse.Common.Models;
using Dfc.FindACourse.Common.Models.FindACourse;

namespace Dfc.FindACourse.Services.Interfaces
{
    public interface ICourseDirectoryService
    {
        IResult<FindACourseSearchResult> CourseDirectorySearch(ICourseSearchCriteria criteria, IPagingOptions options);

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

        IResult<FindACourseDetail> CourseItemDetail(string courseid, int? opportunityId);
    }
}