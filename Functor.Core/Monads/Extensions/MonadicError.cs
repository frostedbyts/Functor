using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Functor.Core.Monads.Extensions
{
    public static class MonadicError
    {
        /* constructor */
        public static MonadicError<TError, TMonad> Instance<TError, TMonad>(TError value, IMonad<TMonad> monad, Func<IMonad<TMonad>, TError> func) => new MonadicError<TError, TMonad>(value, monad, func);

        /* functions */
        public delegate IMonad<TMonad> ThrowError<TError, TMonad>(TError error);

        public delegate IMonad<TMonad> CatchError<TError, TMonad>(IMonad<TMonad> m, Func<TError, IMonad<TMonad>> func);
    }
}
