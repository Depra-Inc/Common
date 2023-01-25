using System;
using Depra.Common.System.Disposable;
using NSubstitute;
using Xunit;

namespace Depra.Common.UnitTests.System.Disposables
{
    public sealed class CompactDisposableTests
    {
        [Fact]
        public void Constructor_ShouldCallInitialize()
        {
            var initialize = Substitute.For<Action>();

            new CompactDisposable(initialize, () => { });

            initialize.Received(1).Invoke();
        }

        [Fact]
        public void Dispose_ShouldCallDispose()
        {
            var dispose = Substitute.For<Action>();

            using (new CompactDisposable(() => { }, dispose)) { }

            dispose.Received(1).Invoke();
        }
    }
}