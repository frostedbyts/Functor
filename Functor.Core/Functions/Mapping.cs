using Functor.Core.Monads;
using Functor.Core.Monads.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functor.Core.Functions
{
    public static class Mapping
    {
        public static ListMonad<TOut> ConcatMap<TIn, TOut>(this ListMonad<TIn> m, Func<TIn, ListMonad<TOut>> func)
        {
            ListMonad<TOut> output = ListMonad.Return(new List<TOut>());
            if(m.Values != null && m.Values.Any())
            {
                foreach(TIn item in m.Values)
                {
                    ListMonad<TOut> temp = func(item);
                    output.Values.AddRange(temp.Values);
                }
            }
            return output;
        }

        public static ListMonad<TOut> ConcatMap<TIn, TOut>(this ListMonad<TIn> m, Func<TIn, TOut> func)
        {
            ListMonad<TOut> output = ListMonad.Return(new List<TOut>());
            if (m.Values != null && m.Values.Any())
            {
                foreach(TIn item in m.Values)
                {
                    TOut temp = func(item);
                    output.Values.Add(temp);
                }
            }
            return output;
        }
    }
}
