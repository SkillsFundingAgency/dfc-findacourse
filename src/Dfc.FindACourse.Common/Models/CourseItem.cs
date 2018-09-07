using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class CourseItem : ValueObject<CourseItem>, ICourseItem
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

        public CourseItem()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Course;
            yield return Opportunity;
            yield return Provider;
        }
    }
}