using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseItemDetail
    {
        ICourseDetails Coursedetails { get; }
        List<IOpportunity> Opportunities { get; }
        IProvider Provider { get; }
        List<IVenue> Venues { get; }
    }
}
