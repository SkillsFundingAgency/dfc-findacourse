﻿using Dfc.FindACourse.Common.Interfaces;
using System;

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
            Name = name;
        }
    }
}