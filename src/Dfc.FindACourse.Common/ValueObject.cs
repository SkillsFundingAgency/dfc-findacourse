using System;
using System.Collections.Generic;
using System.Linq;

namespace Dfc.FindACourse.Common
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            var valueObject = obj as ValueObject<T>;

            if (valueObject is null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
