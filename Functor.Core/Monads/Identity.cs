using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct Identity<T> : IEquatable<Identity<T>>, IEquatable<T>, IMonad<T>
    {
        public T Value { get; }

        internal Identity(T value)
        {
            Value = value;
        }

        public IMonad<TOut> Bind<TOut>(Func<T, IMonad<TOut>> binder)
        {
            return binder(Value);
        }

        public IMonad<T> Return(T value) => new Identity<T>(value);

        public bool Equals(Identity<T> other)
        {
            return (Value == null && other.Value == null) || EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public bool Equals(T other)
        {
            return Value != null && EqualityComparer<T>.Default.Equals(Value, other);
        }
    }
}
