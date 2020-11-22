using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
    {
        public T Value { get; }
        internal Maybe(T value)
        {
            Value = value;
        }

        public bool IsSomething => Value != null;

        public bool IsNothing => !IsSomething;

        public static Maybe<T> Nothing() => new Maybe<T>(default);

        public static Maybe<T> Something(T value) => new Maybe<T>(value);

        public override string ToString() => IsSomething ? $"{Value}" : $"Nothing<{typeof(T).Name}>";

        public bool Equals(T other) => IsSomething && EqualityComparer<T>.Default.Equals(Value, other);

        public override bool Equals(object obj) => obj is Maybe<T> && Equals((Maybe<T>)obj);

        public bool Equals(Maybe<T> other) => (IsNothing && other.IsNothing) || (IsSomething && other.IsSomething && EqualityComparer<T>.Default.Equals(Value, other.Value));

        public override int GetHashCode()
        {
            unchecked
            {
                return IsNothing ? base.GetHashCode() : Value == null ? base.GetHashCode() : Value.GetHashCode();
            }
        }

        public static bool operator ==(Maybe<T> left, Maybe<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Maybe<T> left, Maybe<T> right)
        {
            return !(left == right);
        }

        public static bool operator ==(in Maybe<T> left, in T right) => left.Equals(right);

        public static bool operator !=(in Maybe<T> left, in T right) => !(left == right);

        public static bool operator ==(in T left, in Maybe<T> right) => right.Equals(left);

        public static bool operator !=(in T left, in Maybe<T> right) => !(right == left);

        public static implicit operator T(in Maybe<T> maybe) => maybe.IsSomething ? maybe.Value : default;
    }
}
