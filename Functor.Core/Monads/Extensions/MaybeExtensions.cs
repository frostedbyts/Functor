using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functor.Core.Monads.Extensions
{
    public static class Maybe
    {
        public static Maybe<U> Bind<T, U>(this Maybe<T> maybe, Func<T, Maybe<U>> func) => maybe.IsSomething ? func(maybe.Value) : Maybe<U>.Nothing();

        public static Maybe<T> FromObject<T>(T value) where T : class
        {
            return value != null ? Maybe<T>.Something(value) : Maybe<T>.Nothing();
        }

        public static Maybe<T> FromNullable<T>(T? value) where T : struct
        {
            return value.HasValue ? Maybe<T>.Something(value.Value) : Maybe<T>.Nothing();
        }

        public static T? ToNullable<T>(Maybe<T> maybe) where T : struct
        {
            return maybe.IsSomething ? maybe.Value : (T?)null;
        }

        public static T ToObject<T>(Maybe<T> maybe) where T : class
        {
            return maybe.IsSomething ? maybe.Value : null;
        }

        public static Maybe<TValue> TryGet<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            return dict.TryGetValue(key, out TValue value) ? Maybe<TValue>.Something(value) : Maybe<TValue>.Nothing();
        }

        public static Maybe<IEnumerable<TValue>> TryGet<TKey, TValue>(this ILookup<TKey, TValue> lookup, TKey key)
        {
            return lookup.Contains(key) ? Maybe<IEnumerable<TValue>>.Something(lookup[key]) : Maybe<IEnumerable<TValue>>.Nothing();
        }

        public static TOut Match<TIn, TOut>(this Maybe<TIn> maybe, Func<TIn, TOut> match, Func<TOut> nothing)
        {
            return maybe.IsSomething ? match(maybe.Value) : nothing();
        }

        public static TOut MatchTo<TIn, TOut>(this Maybe<TIn> maybe, TOut something, TOut nothing)
        {
            return maybe.IsSomething ? something : nothing;
        }

        public static Maybe<TOut> Map<TIn, TOut>(this Maybe<TIn> maybe, Func<TIn, TOut> map)
        {
            return maybe.IsSomething ? Maybe<TOut>.Something(map(maybe.Value)) : Maybe<TOut>.Nothing();
        }

        public static T GetOrDefault<T>(this Maybe<T> maybe, T none = default)
        {
            return maybe.IsSomething ? maybe.Value : none;
        }

        public static TOut GetOrDefault<TIn, TOut>(this Maybe<TIn> maybe, Func<TIn, TOut> get, TOut none = default)
        {
            return maybe.IsSomething ? get(maybe.Value) : none;
        }

        public static Maybe<T> Do<T>(this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.IsSomething)
                action(maybe.Value);
            return maybe;
        }

        public static Maybe<T> DoWhenNothing<T>(this Maybe<T> maybe, Action action)
        {
            if (maybe.IsNothing)
                action();
            return maybe;
        }

        public static IEnumerable<T> Choose<T>(this IEnumerable<Maybe<T>> items)
        {
            return items.Where(m => m.IsSomething).Select(m => m.Value);
        }

        public static Maybe<IEnumerable<T>> Sequence<T>(this IEnumerable<Maybe<T>> items)
        {
            return items.Any(m => m.IsNothing) ? Maybe<IEnumerable<T>>.Nothing() : Maybe<IEnumerable<T>>.Something(items.Select(m => m.Value));
        }

        public static Maybe<T> Find<T>(this IEnumerable<T> items, Func<T,bool> func)
        {
            if(items != null && items.Any())
            {
                foreach (T item in items)
                    if (func(item))
                        return Maybe<T>.Something(item);
            }
            return Maybe<T>.Nothing();
        }

        public static Maybe<T> First<T>(this IEnumerable<T> items)
        {
            if (items == null || !items.Any())
                return Maybe<T>.Nothing();
            if (items.Any())
                return Maybe<T>.Something(items.First());
            return Maybe<T>.Nothing();
        }

        public static Maybe<T> ElementAt<T>(this IEnumerable<T> items, int index)
        {
            if (items == null || !items.Any() || index < 0)
                return Maybe<T>.Nothing();
            IList<T> list = items as IList<T>;
            if(list != null)
            {
                if (list.Count >= index + 1)
                    return Maybe<T>.Something(list[index]);
                else
                {
                    for(int i = 0; i < list.Count; i++)
                    {
                        if (i == index)
                            return Maybe<T>.Something(list[i]);
                    }
                }
            }
            return Maybe<T>.Nothing();
        }

    }
}
