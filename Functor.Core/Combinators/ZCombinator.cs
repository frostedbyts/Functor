using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Combinators
{
    public static class ZCombinator
    {
        private delegate Func<T, TResult> Recursive<T, TResult>(Recursive<T, TResult> r);
        public static Func<Func<Func<T, TResult>, Func<T, TResult>>, Func<T, TResult>> Fix<T, TResult>(this Func<Func<T,TResult>, Func<T, TResult>> f)
        {
            return f => ((Recursive<T, TResult>)(g => f(x => g(g)(x))))(g => f(x => g(g)(x)));
        }
    }
}
