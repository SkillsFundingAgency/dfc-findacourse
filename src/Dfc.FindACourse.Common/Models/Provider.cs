using Dfc.FindACourse.Common.Interfaces;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Dfc.FindACourse.Common.UnitTests")]

namespace Dfc.FindACourse.Common.Models
{
    public class Provider : IProvider
    {
        public int Id { get; }
        public string Name { get; }

        public Provider(int id, string name)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null, empty or only whitespace.");

            Id = id;
            Name = NameFormatting(name);
        }

        internal static string NameFormatting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            var split = name.Split(" ");

            if (split.Length == 1)
                return name;

            return name.ToSentenceCase();
        }
    }
}