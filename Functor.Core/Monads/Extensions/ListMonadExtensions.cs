using Functor.Core.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Functor.Core.Monads.Extensions
{
    public static class ListMonad
    {
        /* binders */
        public static ListMonad<TOut> Bind<TIn, TOut>(this ListMonad<TIn> m, Func<TIn, ListMonad<TOut>> binder) => m.ConcatMap(binder);

        public static ListMonad<TOut> Bind<TIn, TOut>(this ListMonad<TIn> m, Func<TIn, TOut> binder) => m.ConcatMap(binder);

        /* constructors */

        public static ListMonad<T> Return<T>(T value) => new ListMonad<T>(value);

        public static ListMonad<T> Return<T>(List<T> values) => new ListMonad<T>(values);

        /* functions */
        public static ListMonad<T> Concat<T>(this ListMonad<T> left, ListMonad<T> right) => left.Values == null && right.Values == null ? Return(new List<T>()) : left.Values == null ? Return(right.Values) : right.Values == null ? Return(left.Values) : Return(left.Values.Concat(right.Values).ToList());

        public static ListMonad<T> Zero<T>() => Return(new List<T>());
    }
}
