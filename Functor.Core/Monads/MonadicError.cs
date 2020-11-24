using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct MonadicError<T,TMonad>
    {
        public T Value { get; }

        public IMonad<TMonad> Monad { get; }

        public Func<IMonad<TMonad>, T> Func { get; }

        internal MonadicError(T value, IMonad<TMonad> monad, Func<IMonad<TMonad>, T> func)
        {
            Value = value;
            Monad = monad;
            Func = func;
        }

    }
}
