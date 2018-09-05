using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models
{
    public class DescriptionDate : ValueObject<DescriptionDate>, IDescriptionDate
    {
        public DateTime? Date { get; }
        public string Description { get; }

        public DescriptionDate(DateTime date)
        {
            Date = date;
        }

        public DescriptionDate(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException($"{nameof(description)} cannot be null, empty or only whitespace.");

            Description = description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
            yield return Description;
        }
    }
}
