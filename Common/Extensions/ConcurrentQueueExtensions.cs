using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="ConcurrentQueue{T}"/> extensions.
    /// </summary>
    public static class ConcurrentQueueExtensions
    {
        public static IEnumerable<T> DequeueExisting<T>(this ConcurrentQueue<T> queue)
        {
            while (queue.TryDequeue(out var item))
            {
                yield return item;
            }
        }
    }
}