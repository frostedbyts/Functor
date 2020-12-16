using System;
using System.Collections.Generic;
using System.Text;
using Functor.Core.Monads.Extensions;
using System.Linq;

namespace Functor.Core.Monads
{
    public readonly struct ListMonad<T> : IEquatable<ListMonad<T>>, IEquatable<List<T>>
    {
        public List<T> Values { get; }

        internal ListMonad(T value)
        {
            Values = new List<T> { value };
        }

        internal ListMonad(List<T> values)
        {
            Values = values;
        }

        public bool Equals(ListMonad<T> other)
        {
            return ((Values == null || !Values.Any()) && (other.Values == null || !other.Values.Any())) || Values.SequenceEqual(other.Values);
        }

        public bool Equals(List<T> other) => ((Values == null || !Values.Any()) && (other == null || !other.Any())) || Values.SequenceEqual(other);

        public static ListMonad<T> operator +(ListMonad<T> left, ListMonad<T> right) => left.Concat(right);

        public static implicit operator List<T>(in ListMonad<T> m) => m.Values;

    }
}
