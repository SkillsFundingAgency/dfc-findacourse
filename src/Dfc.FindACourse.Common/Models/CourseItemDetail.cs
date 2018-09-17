using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseItemDetail : ValueObject<CourseItemDetail>, ICourseItemDetail
    {
       

        public ICourseDetails Coursedetails { get; }
        public List<Interfaces.IOpportunity> Opportunities { get; }
        public IProvider Provider { get; }
        public IVenue Venue { get; }

        public CourseItemDetail(
            ICourseDetails courseDetails,
            List<IOpportunity> opportunities,
            IProvider provider, 
            IVenue venue)
        {
            Coursedetails = courseDetails ?? throw new ArgumentNullException(nameof(courseDetails));
            Opportunities = opportunities ?? throw new ArgumentNullException(nameof(opportunities));
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            //Venue is now nullable since it could be a distance course with a Region
            Venue = venue;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
