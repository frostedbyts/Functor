using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Monads.Extensions
{
    public static class IdentityExtensions
    {
        public static Identity<T> Return<T>(T value) => new Identity<T>(value);

        public static T RunIdentity<T>(this Identity<T> identity) => identity.Value;

        public static Identity<U> Bind<T,U>(this Identity<T> identity, Func<T, U> binder) => Return(binder(identity.Value));
    }
}
