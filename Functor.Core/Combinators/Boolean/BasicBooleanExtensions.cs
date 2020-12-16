using System;
using System.Collections.Generic;
using System.Text;

namespace Functor.Core.Combinators.Boolean
{
    public static class BasicBooleanExtensions
    {
        public static Func<T, bool> And<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) =>
            {
                return a(t) && b(t);
            };
        }

        public static Func<T, bool> Or<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) => { return a(t) || b(t); };
        }

        public static Func<T, bool> Not<T>(this Func<T, bool> func)
        {
            return (T t) =>
            {
                return !func(t);
            };
        }

        public static Func<T, bool> Xor<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) =>
            {
                return (a(t) || b(t)) && !(a(t) && b(t));
            };
        }

        public static Func<T, bool> Nand<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) =>
            {
                return !a.And(b)(t);
            };
        }

        public static Func<T, bool> Nor<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) =>
            {
                return !a.Or(b)(t);
            };
        }

        public static Func<T, bool> Implies<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) =>
            {
                return a.Not().Or(b)(t);
            };
        }

        public static Func<T, bool> Biconditional<T>(this Func<T, bool> a, Func<T, bool> b)
        {
            return (T t) =>
            {
                return a.Implies(b)(t) && b.Implies(a)(t);
            };
        }

        public static Func<T1, T2, bool> And<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (T1 t1, T2 t2) =>
            {
                return a(t1, t2) && b(t1, t2);
            };
        }

        public static Func<T1, T2, bool> Or<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (T1 t1, T2 t2) =>
            {
                return a(t1, t2) || b(t1, t2);
            };
        }

        public static Func<T1, T2, bool> Not<T1, T2>(this Func<T1, T2, bool> func)
        {
            return (T1 t1, T2 t2) =>
            {
                return !func(t1, t2);
            };
        }

        public static Func<T1, T2, bool> Xor<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (t1, t2) =>
            {
                return (a(t1, t2) || b(t1, t2)) && !(a(t1, t2) && b(t1, t2));
            };
        }

        public static Func<T1, T2, bool> Nand<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (t1, t2) =>
            {
                return !a.And(b)(t1, t2);
            };
        }

        public static Func<T1, T2, bool> Nor<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (t1, t2) =>
            {
                return !a.Or(b)(t1, t2);
            };
        }

        public static Func<T1, T2, bool> Implies<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (t1, t2) =>
            {
                return a.Not().Or(b)(t1, t2);
            };
        }

        public static Func<T1, T2, bool> Biconditional<T1, T2>(this Func<T1, T2, bool> a, Func<T1, T2, bool> b)
        {
            return (t1, t2) =>
            {
                return a.Implies(b)(t1, t2) && b.Implies(a)(t1, t2);
            };
        }

        public static Func<T1, T2, T3, bool> And<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) =>
            {
                return a(t1, t2, t3) && b(t1, t2, t3);
            };
        }

        public static Func<T1, T2, T3, bool> Or<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) => { return a(t1, t2, t3) || b(t1, t2, t3); };
        }

        public static Func<T1, T2, T3, bool> Not<T1, T2, T3>(this Func<T1, T2, T3, bool> func)
        {
            return (t1, t2, t3) => { return !func(t1, t2, t3); };
        }

        public static Func<T1, T2, T3, bool> Xor<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) => { return a.Or(b)(t1, t2, t3) && !a.And(b)(t1, t2, t3); };
        }

        public static Func<T1, T2, T3, bool> Nand<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) => { return !a.And(b)(t1, t2, t3); };
        }

        public static Func<T1, T2, T3, bool> Nor<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) => { return !a.Or(b)(t1, t2, t3); };
        }

        public static Func<T1, T2, T3, bool> Implies<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) => { return a.Not().Or(b)(t1, t2, t3); };
        }

        public static Func<T1, T2, T3, bool> Biconditional<T1, T2, T3>(this Func<T1, T2, T3, bool> a, Func<T1, T2, T3, bool> b)
        {
            return (t1, t2, t3) => { return a.Implies(b)(t1, t2, t3) && b.Implies(a)(t1, t2, t3); };
        }

        public static Func<T1,T2,T3,T4,bool> And<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return a(t1, t2, t3, t4) && b(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Or<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return a(t1, t2, t3, t4) || b(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Not<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> func)
        {
            return (t1, t2, t3, t4) => { return !func(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Nand<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return !a.And(b)(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Nor<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return !a.Or(b)(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Xor<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return a.Or(b)(t1, t2, t3, t4) && !a.And(b)(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Implies<T1,T2,T3,T4>(this Func<T1,T2,T3,T4, bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return a.Not().Or(b)(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,bool> Biconditional<T1,T2,T3,T4>(this Func<T1,T2,T3,T4,bool> a, Func<T1,T2,T3,T4,bool> b)
        {
            return (t1, t2, t3, t4) => { return a.Implies(b)(t1, t2, t3, t4) && b.Implies(a)(t1, t2, t3, t4); };
        }

        public static Func<T1,T2,T3,T4,T5,bool> And<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => { return a(t1, t2, t3, t4, t5) && b(t1, t2, t3, t4, t5); };
        }

        public static Func<T1,T2,T3,T4,T5,bool> Or<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => { return a(t1, t2, t3, t4, t5) || b(t1, t2, t3, t4, t5); };
        }

        public static Func<T1,T2,T3,T4,T5,bool> Not<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> func)
        {
            return (t1, t2, t3, t4, t5) => !func(t1, t2, t3, t4, t5);
        }

        public static Func<T1,T2,T3,T4,T5,bool> Xor<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => a.Or(b)(t1, t2, t3, t4, t5) && !a.And(b)(t1, t2, t3, t4, t5);
        }

        public static Func<T1,T2,T3,T4,T5,bool> Nand<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => !a.And(b)(t1, t2, t3, t4, t5);
        }

        public static Func<T1,T2,T3,T4,T5,bool> Nor<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => !a.Or(b)(t1, t2, t3, t4, t5);
        }

        public static Func<T1,T2,T3,T4,T5,bool> Implies<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => a.Not().Or(b)(t1, t2, t3, t4, t5);
        }

        public static Func<T1,T2,T3,T4,T5,bool> Biconditional<T1,T2,T3,T4,T5>(this Func<T1,T2,T3,T4,T5,bool> a, Func<T1,T2,T3,T4,T5,bool> b)
        {
            return (t1, t2, t3, t4, t5) => a.Implies(b)(t1, t2, t3, t4, t5) && b.Implies(a)(t1, t2, t3, t4, t5);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> And<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> a, Func<T1,T2,T3,T4,T5,T6,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6) => a(t1, t2, t3, t4, t5, t6) && b(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> Or<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> a, Func<T1,T2,T3,T4,T5,T6,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6) => a(t1, t2, t3, t4, t5, t6) || b(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> Not<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> func)
        {
            return (t1, t2, t3, t4, t5, t6) => !func(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> Nand<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> a, Func<T1,T2,T3,T4,T5,T6,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6) => !a.And(b)(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> Nor<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> a, Func<T1,T2,T3,T4,T5,T6,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6) => !a.Or(b)(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> Implies<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> a, Func<T1,T2,T3,T4,T5,T6,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6) => a.Not().Or(b)(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,bool> Biconditional<T1,T2,T3,T4,T5,T6>(this Func<T1,T2,T3,T4,T5,T6,bool> a, Func<T1,T2,T3,T4,T5,T6,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6) => a.Implies(b)(t1, t2, t3, t4, t5, t6) && b.Implies(a)(t1, t2, t3, t4, t5, t6);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> And<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => a(t1, t2, t3, t4, t5, t6, t7) && b(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> Or<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => a(t1, t2, t3, t4, t5, t6, t7) || b(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> Not<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> func)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => !func(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> Nand<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => !a.And(b)(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> Nor<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => !a.Or(b)(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> Implies<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => a.Not().Or(b)(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,bool> Biconditional<T1,T2,T3,T4,T5,T6,T7>(this Func<T1,T2,T3,T4,T5,T6,T7,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7) => a.Implies(b)(t1, t2, t3, t4, t5, t6, t7) && b.Implies(a)(t1, t2, t3, t4, t5, t6, t7);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> And<T1,T2,T3,T4,T5,T6,T7,T8>(this Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8) => a(t1, t2, t3, t4, t5, t6, t7, t8) && b(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> Or<T1,T2,T3,T4,T5,T6,T7,T8>(this Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> a, Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> b)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8) => a(t1, t2, t3, t4, t5, t6, t7, t8) || b(t1, t2, t3, t4, t5, t6, t7, t8);
        }

        public static Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> Not<T1,T2,T3,T4,T5,T6,T7,T8>(this Func<T1,T2,T3,T4,T5,T6,T7,T8,bool> func)
        {
            return (t1, t2, t3, t4, t5, t6, t7, t8) => !func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
    }
}
