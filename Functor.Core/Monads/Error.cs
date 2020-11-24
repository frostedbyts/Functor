using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public class Error<T> where T : Exception, IMonad<T>
    {
        public T Value { get; }

        public string Message { get; }

        public Error()
        {
            Value = default;
            Message = typeof(T).Name;
        }

        private Error(T value)
        {
            Value = value;
            Message = typeof(T).Name;
        }

        private Error(T value, string message)
        {
            Value = value;
            Message = message;
        }

        public static Error<T> NoMsg(T value)
        {
            return new Error<T>(value);
        }

        public static Error<T> StringMsg(T value, string message)
        {
            return new Error<T>(value, message);
        }

        public IMonad<TOut> Bind<TOut>(Func<T, IMonad<TOut>> binder)
        {
            return Value != null ? binder(Value) : default;
        }
    }
}
