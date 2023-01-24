using System;
using Depra.Common.Extensions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions
{
    public sealed partial class FunctionalExtensionsTests
    {
        public class As
        {
            [Fact]
            public void As_ShouldApplyMapFunction() =>
                Assert.Equal(10, 1.As(x => x + 1).As(x => x * 10).As(x => x / 2));
                        
            [Fact]
            public void As_ShouldThrowException_IfMapIsNull() =>
                Assert.Throws<ArgumentNullException>(() => "".As<string, int>(null));
        }
    }
}