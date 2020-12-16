using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct State<TState, TValue>
    {
        public Func<TState, Tuple<TValue, TState>> Transition { get; }

        internal State(Func<TState, Tuple<TValue, TState>> transition)
        {
            Transition = transition;
        }
    }
}
