﻿using System.Threading;

namespace Depra.Common.System.Threading
{
    public static partial class Atomically
    {
        public static int Change(ref int self, int from, int to) =>
            Interlocked.CompareExchange(ref self, to, from);

        public static long Change(ref long self, long from, long to) =>
            Interlocked.CompareExchange(ref self, to, from);

        public static float Change(ref float self, float from, float to) =>
            Interlocked.CompareExchange(ref self, to, from);

        public static double Change(ref double self, double from, double to) =>
            Interlocked.CompareExchange(ref self, to, from);

        public static object Change(ref object self, object from, object to) =>
            Interlocked.CompareExchange(ref self, to, from);

        public static T Change<T>(ref T self, T from, T to) where T : class =>
            Interlocked.CompareExchange(ref self, to, from);

        public static int Change(ref int self, int to) =>
            Interlocked.Exchange(ref self, to);

        public static long Change(ref long self, long to) =>
            Interlocked.Exchange(ref self, to);

        public static float Change(ref float self, float to) =>
            Interlocked.Exchange(ref self, to);

        public static double Change(ref double self, double to) =>
            Interlocked.Exchange(ref self, to);

        public static object Change(ref object self, object to) =>
            Interlocked.Exchange(ref self, to);

        public static T Change<T>(ref T self, T to) where T : class =>
            Interlocked.Exchange(ref self, to);
    }
}