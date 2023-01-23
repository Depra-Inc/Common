namespace Depra.Common.System.Threading
{
    public static partial class Atomically
    {
        public static bool Changed(ref int self, int from, int to) =>
            Change(ref self, from, to) == from;

        public static bool Changed(ref long self, long from, long to) =>
            Change(ref self, from, to) == from;

        public static bool Changed(ref float self, float from, float to) =>
            Change(ref self, from, to) == from;

        public static bool Changed(ref double self, double from, double to) =>
            Change(ref self, from, to) == from;

        public static bool Changed(ref object self, object from, object to) =>
            Change(ref self, from, to) == from;

        public static bool Changed<T>(ref T self, T from, T to) where T : class =>
            Change(ref self, from, to) == from;
    }
}