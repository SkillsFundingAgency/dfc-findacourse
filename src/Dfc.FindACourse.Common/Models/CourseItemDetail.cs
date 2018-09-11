using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseItemDetail : ValueObject<CourseItemDetail>, ICourseItemDetail
    {
        public ICourseDetails Coursedetails { get; }
        public IOpportunity Opportunity { get; }
        public IProvider Provider { get; }
        public IVenue Venue { get; }

        public CourseItemDetail(
            ICourseDetails courseDetails,
            IOpportunity opportunity,
            IProvider provider, 
            IVenue  venue)
        {
            Coursedetails = courseDetails ?? throw new ArgumentNullException(nameof(courseDetails));
            Opportunity = opportunity ?? throw new ArgumentNullException(nameof(opportunity));
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Venue = venue ?? throw new ArgumentNullException(nameof(venue));
        }

      
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
