using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct Monad<T> : IMonad<T>
    {
        public T Value { get; }

        internal Monad(T value)
        {
            Value = value;
        }
        public IMonad<TOut> Bind<TOut>(Func<T, IMonad<TOut>> binder)
        {
            return binder(Value);
        }

        public IMonad<T> Return(T value)
        {
            return new Monad<T>(value);
        }
    }
}
