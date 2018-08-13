using Dfc.FindACourse.Common.Interfaces;
using System;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseItem : ICourseItem
    {
        public ICourse Course { get; }
        public IOpportunity Opportunity { get; }
        public IProvider Provider { get; }

        public CourseItem(
            ICourse course,
            IOpportunity opportunity,
            IProvider provider)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            if (opportunity == null)
                throw new ArgumentNullException(nameof(opportunity));
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            Course = course;
            Opportunity = opportunity;
            Provider = provider;
        }
    }
}