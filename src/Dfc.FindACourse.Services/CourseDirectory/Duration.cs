using Dfc.FindACourse.Services.CourseDirectory.Interfaces;
using System;

namespace Dfc.FindACourse.Services.CourseDirectory
{
    public class Duration : IDuration
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
    }
}