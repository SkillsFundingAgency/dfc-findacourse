using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class Venue : ValueObject<Venue>, IVenue
    {
        public string Name { get; }
        public IAddress Address { get; }
        public double? Distance { get; }
        public Venue(Provider provider)
        {
            Name = provider.Name;
            Address = provider.ProviderAddress;
            Distance = null;
        }
        /// <summary>
        /// Added to compensate for a NULL Venue being set to a course, which in theiory is not possible
        /// But was also item 12 on the Tribal developements, that was not opted for, or is configurbale
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="distance"></param>
        public Venue(string name, IAddress address, double? distance = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");
            if (address == null)
                throw new ArgumentNullException(nameof(address));
            if (distance.HasValue && distance.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(distance));

            Name = name.ToSentenceCase();
            Address = address;
            Distance = distance;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Distance;
        }
    }
}