using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads
{
    public readonly struct Unit : IEquatable<Unit>
    {
        private static Unit _default = default;
        public static ref readonly Unit Default => ref _default;

        public bool Equals(Unit other) => true;

        public override bool Equals(object obj) => obj is Unit;

        public override int GetHashCode() => 0;

        public override string ToString() => "()";

        public static bool operator ==(in Unit first, in Unit second) => true;

        public static bool operator !=(in Unit first, in Unit second) => false;
        
    }
}
