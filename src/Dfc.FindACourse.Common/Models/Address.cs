using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class Address : ValueObject<Address>, IAddress
    {
        public string Line1 { get; }
        public string Line2 { get; }
        public string Town { get; }
        public string County { get; }
        public string Postcode { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        public Address(
            string line1,
            string line2,
            string town,
            string county,
            string postcode,
            double latitude,
            double longitude)
        {
            if (string.IsNullOrWhiteSpace(line1))
                throw new ArgumentException($"{nameof(line1)} cannot be null, empty or only whitespace.");
            //if (string.IsNullOrWhiteSpace(line2))
            //    throw new ArgumentException($"{nameof(line2)} cannot be null, empty or only whitespace.");
            if (string.IsNullOrWhiteSpace(town))
                throw new ArgumentException($"{nameof(town)} cannot be null, empty or only whitespace.");
            //if (string.IsNullOrWhiteSpace(county))
            //    throw new ArgumentException($"{nameof(county)} cannot be null, empty or only whitespace.");
            if (string.IsNullOrWhiteSpace(postcode))
                throw new ArgumentException($"{nameof(postcode)} cannot be null, empty or only whitespace.");
            if (latitude < -180 || latitude > 180)
                throw new ArgumentOutOfRangeException(nameof(latitude));
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException(nameof(longitude));

            Line1 = line1;
            Line2 = line2;
            Town = town;
            County = county;
            Postcode = postcode;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Line1;
            yield return Line2;
            yield return Town;
            yield return County;
            yield return Postcode;
            yield return Latitude;
            yield return Longitude;
        }
    }
}