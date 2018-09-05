using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.FindACourse.Common.Models
{
    public class DescriptionDate : ValueObject<DescriptionDate>, IDescriptionDate
    {
        private static readonly string _defaultDescription = "Not available";

        public static DescriptionDate Default => new DescriptionDate(_defaultDescription);

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
        public override string ToString()
        {
            if (Date.HasValue)
            {
                return Date.Value.ToString("d MMMM yyyy");
            }

            return Description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
            yield return Description;
        }
    }
}
