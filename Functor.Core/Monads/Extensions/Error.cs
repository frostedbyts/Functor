using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads.Extensions
{
    public static class Error
    {
        public static Error<T> NoMsg<T>(T value)
        {
            return new Error<T>(value);
        }

        public static Error<T> StrMsg<T>(T value, string msg)
        {
            return new Error<T>(value, msg);
        }

        public static Error<T> ThrowError<T>(this T value)
        {
            return NoMsg(value);
        }

        public static Error<T> ThrowError<T>(this T value, string message)
        {
            return StrMsg(value, message);
        }

        public static Error<T> HandleError<T>(this Error<T> m, Func<T, Error<T>> handler) 
        {
            return handler(m.Value);
        }
        
    }
}
