using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct Identity<T> : IMonad<T>
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
    }
}
