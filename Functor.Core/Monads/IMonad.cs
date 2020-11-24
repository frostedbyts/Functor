using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public interface IMonad<T>
    {
        public T Value { get; }
        public IMonad<TOut> Bind<TOut>(Func<T, IMonad<TOut>> binder);
    }
}
