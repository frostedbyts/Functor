using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct Error<T> : IMonad<T> 
    {
        public T Value { get; }

        public string Message { get; }

        internal Error(T value)
        {
            Value = value;
            Message = typeof(T).FullName;
        }

        internal Error(T value, string message)
        {
            Value = value;
            Message = message;
        }

        public IMonad<TOut> Bind<TOut>(Func<T, IMonad<TOut>> binder) => IsError(typeof(IMonad<TOut>), typeof(TOut)) ? new Error<TOut>((TOut)Activator.CreateInstance(typeof(TOut))) : binder(Value);

        public IMonad<T> Return(T value) => new Error<T>(value);

        private static bool IsError(Type monadType, Type valueType)
        {
            return typeof(Error<T>).IsAssignableFrom(monadType) && (typeof(Exception).IsAssignableFrom(valueType) || valueType == typeof(Exception));
        }
    }
}
