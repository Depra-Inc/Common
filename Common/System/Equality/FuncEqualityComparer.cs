using System;
using System.Collections.Generic;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.System.Equality
{
    public class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _func;

        public FuncEqualityComparer(Func<T, T, bool> func)
        {
            Ensure(func).NotNull();
            
            _func = func;
        }

        public bool Equals(T x, T y) => _func(x, y);
        public int GetHashCode(T obj) => obj.GetHashCode();
    }
}