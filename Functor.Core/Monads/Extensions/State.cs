using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads.Extensions
{
    public static class State
    {
        public static Tuple<TValue, TState> RunState<TValue, TState>(this State<TState, TValue> st, TState state) => st.Transition(state);

        public static State<TState, TValue> Return<TState, TValue>(TValue value) => new State<TState, TValue>(st => Tuple.Create(value, st));

        //bind essentially runs a chain of state processors from an initial state and effectively returns the 3rd state processor in the chain
        public static State<TState, TOut> Bind<TState, TValue, TOut>(this State<TState, TValue> s, Func<TValue, State<TState, TOut>> binder)
        {
            return new State<TState, TOut>(s0 =>
            {
                Tuple<TValue, TState> result = s.RunState(s0); //run initial state processor
                TValue x = result.Item1;
                TState s1 = result.Item2;
                State<TState, TOut> st = binder(x); //binder creates the second state processor
                return st.RunState(s1); //run second state processor
            });
        }
        

    }
}
