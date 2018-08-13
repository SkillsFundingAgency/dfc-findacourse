using Dfc.FindACourse.Services.CourseDirectory.Interfaces;
using System;

namespace Dfc.FindACourse.Services.CourseDirectory
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