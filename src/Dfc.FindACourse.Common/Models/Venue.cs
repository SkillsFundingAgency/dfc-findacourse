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

        public Venue(string name, IAddress address, double? distance = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");
            if (address == null)
                throw new ArgumentNullException(nameof(address));
            if (distance.HasValue && distance.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(distance));

            Name = name;
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