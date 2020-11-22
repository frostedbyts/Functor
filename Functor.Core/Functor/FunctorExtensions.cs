using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Functor
{
    public static partial class Functor
    {
        /// <summary>
        /// Creates an instance of <see cref="Functor{T}"/> encapsulating the provided value where <typeparamref name="T"/> must be a concrete type.
        /// </summary>
        /// <typeparam name="T">Type of the value to be encapsulated which must be a concrete type</typeparam>
        /// <param name="value">The value to be encapsulated</param>
        /// <returns></returns>
        public static Functor<T> Instance<T>(T value) => new Functor<T>(value);
        /// <summary>
        /// Given the <paramref name="functor"/> of type <see cref="Functor{T}"/> and a <paramref name="func"/> of type <see cref="Func{T, TResult}"/> return a <c>Functor</c> of type <c>Functor&lt;TResult&gt;</c>
        /// </summary>
        /// <remarks>
        /// Essentially, this is mapping <paramref name="functor"/> to a <c>Functor</c> of type <c>Functor&lt;TResult&gt;</c> using <paramref name="func"/>. Effectively it is applying <paramref name="func"/> to the <c>Value</c> of <paramref name="functor"/>
        /// to obtain a <c>result</c> of type <typeparamref name="TResult"/> which is then used to instance a <c>Functor</c> of type <c>Functor&lt;TResult&gt;</c>
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="functor"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Functor<TResult> Fmap<T,TResult>(this Functor<T> functor, Func<T,TResult> func)
        {
            TResult result = func(functor.Value);
            return Instance(result);
        }
    }
}
