﻿using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class Venue : ValueObject<Venue>, IVenue
    {
        public string VenueId { get; }
        public string Name { get; }
        public IAddress Address { get; }
        public double? Distance { get; }
        public string Website { get; }
        /// <summary>
        /// Not used at the moment since replaced by NULL and direct use of Provider Details
        /// </summary>
        /// <param name="provider"></param>
        public Venue(Provider provider)
        {

            if (string.IsNullOrWhiteSpace(provider.Name))
                throw new ArgumentException($"{nameof(provider.Name)} cannot be null, empty or only whitespace.");
            Name = provider.Name;
            Address = provider.ProviderAddress ?? throw new ArgumentNullException(nameof(provider.ProviderAddress)); ;
            Distance = null;
        }
        /// <summary>
        /// Added to compensate for a NULL Venue being set to a course, which in theiory is not possible
        /// But was also item 12 on the Tribal developements, that was not opted for, or is configurbale
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="distance"></param>
        public Venue(string name, IAddress address, string website, double? distance = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");
            if (distance.HasValue && distance.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(distance));

            Name = name.ToSentenceCase();
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Distance = distance;
            Website = Uri.IsWellFormedUriString(website, UriKind.Absolute) ? website : string.Empty;
        }
        public Venue(string name, IAddress address, double? distance = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");
            if (distance.HasValue && distance.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(distance));

            Name = name.ToSentenceCase();
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Distance = distance;
           
        }
        public Venue(string venueid, string name, IAddress address, string website, double? distance = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");
            if (distance.HasValue && distance.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(distance));
            VenueId = venueid;
            Name = name.ToSentenceCase();
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Distance = distance;
            Website = Uri.IsWellFormedUriString(website, UriKind.Absolute) ? website : string.Empty;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Distance;
        }
    }
}