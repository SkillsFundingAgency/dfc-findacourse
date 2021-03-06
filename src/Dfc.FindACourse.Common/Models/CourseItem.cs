﻿using Dfc.FindACourse.Common.Interfaces;
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
            Course = course ?? throw new ArgumentNullException(nameof(course));
            Opportunity = opportunity ?? throw new ArgumentNullException(nameof(opportunity));
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
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