﻿using System.Collections.Generic;

namespace Depra.Common.System.Threading
{
    public static class Concurrently
    {
        public static void Add<T>(T item, IList<T> to) => Add(item, to, with: to);

        public static void Add<T>(T item, IList<T> to, object with)
        {
            lock (with) to.Add(item);
        }
    }
}