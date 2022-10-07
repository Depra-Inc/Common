using System.Diagnostics;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="Stopwatch"/> extensions.
    /// </summary>
    public static class StopwatchExtension
    {
        public static long ElapsedSeconds(this Stopwatch sw) => sw.ElapsedMilliseconds / 1000;
    }
}