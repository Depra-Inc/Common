using System.Threading;

namespace Depra.Common.System.Threading
{
    public static partial class Atomically
    {
        public static int Increment(ref int self) =>
            Interlocked.Increment(ref self);

        public static long Increment(ref long self) =>
            Interlocked.Increment(ref self);

        public static void Add(ref int self, int value) =>
            Interlocked.Add(ref self, value);

        public static void Add(ref long self, long value) =>
            Interlocked.Add(ref self, value);
    }
}