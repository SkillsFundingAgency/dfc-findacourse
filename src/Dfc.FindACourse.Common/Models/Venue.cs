using Dfc.FindACourse.Common.Interfaces;
using System;

namespace Dfc.FindACourse.Common.Models
{
    public class Venue : IVenue
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

            Name = name;
            Address = address;
            Distance = distance;
        }
    }
}