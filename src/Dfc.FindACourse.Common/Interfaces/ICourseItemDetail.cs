using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Interfaces
{
    public interface ICourseItemDetail
    {
        ICourseDetails Coursedetails { get; }
        IOpportunity Opportunity { get; }
        IProvider Provider { get; }
        IVenue Venue { get; }
    }
}
