using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Functor
{
    public readonly struct Functor<T>
    {
        public T Value { get; }

        internal Functor(T value)
        {
            Value = value;
        }
    }
}
