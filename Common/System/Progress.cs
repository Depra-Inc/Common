using System;

namespace Depra.Common.System
{
    public static class Progress
    {
        public static IProgress<T> Fake<T>() => FakeOf<T>.Instance;

        private class FakeOf<T> : IProgress<T>
        {
            public static readonly IProgress<T> Instance = new FakeOf<T>();
            public void Report(T value) { }
        }
    }
}