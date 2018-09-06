using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Dfc.FindACourse.Common.Models
{
    public class Duration : ValueObject<Duration>, IDuration
    {
        private static readonly string _defaultDescription = "Not available";

        public static Duration Default => new Duration(_defaultDescription);

        public double Value { get; }
        public string Unit { get; }
        public string Description { get; }

        private bool HasValue => Value >= 0;
        private bool HasUnit => !string.IsNullOrWhiteSpace(Unit);

        public Duration(double value, string unit, string description)
        {
            GuardValue(value);
            GuardUnit(unit);
            GuardDescription(description);

            Value = value;
            Unit = UnitFormatting(value, unit);
            Description = description;
        }

        public Duration(double value, string unit)
        {
            GuardValue(value);
            GuardUnit(unit);

            Value = value;
            Unit = UnitFormatting(value, unit);
        }

        public Duration(string description)
        {
            GuardDescription(description);

            Description = description;
        }

        internal static void GuardValue(double value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
        }

        internal static void GuardUnit(string unit)
        {
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException($"{nameof(unit)} cannot be null, empty or only whitespace.");
        }

        internal static void GuardDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException($"{nameof(description)} cannot be null, empty or only whitespace.");
        }

        internal static string UnitFormatting(double value, string unit)
        {
            if (value == 1)
                return unit.RemoveFromEnd("(s)");

            if (value > 1)
                return unit.RemoveFromEnd("(s)") + "s";

            return unit;
        }

        public override string ToString()
        {
            if (HasValue && HasUnit)
            {
                return $"{Value} {Unit}";
            }

            return Description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
            yield return Description;
        }
    }
}