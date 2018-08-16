using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class Duration : ValueObject<Duration>, IDuration
    {
        public static Duration NotKnown = new Duration(0, "NotKnown");

        public double Value { get; }
        public string Unit { get; }

        public Duration(double value, string unit)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException($"{nameof(unit)} cannot be null, empty or only whitespace.");

            Value = value;
            Unit = unit;
        }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }
    }
}