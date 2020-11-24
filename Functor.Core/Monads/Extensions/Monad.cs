using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads.Extensions
{
    public static class Monad
    {
        public static Monad<T> Return<T>(this T instance) => new Monad<T>(instance);
    }
}
