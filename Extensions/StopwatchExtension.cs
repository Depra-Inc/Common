using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="Stopwatch"/> extensions.
    /// </summary>
    public static class StopwatchExtension
    {
        private const long THOUSAND = 1_000L;
        private const long MILLION = 1_000_000L;
        private const long BILLION = 1_000_000_000L;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ElapsedSeconds(this Stopwatch sw) => sw.ElapsedMilliseconds / THOUSAND;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ElapsedMicroseconds(this Stopwatch watch) =>
            (long) ((double) watch.ElapsedTicks / Stopwatch.Frequency * MILLION);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ElapsedNanoseconds(this Stopwatch watch) =>
            (long) ((double) watch.ElapsedTicks / Stopwatch.Frequency * BILLION);
    }
}