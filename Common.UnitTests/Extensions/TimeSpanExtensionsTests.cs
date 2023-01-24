#nullable enable
using Depra.Common.Extensions;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions
{
    public sealed class TimeSpanExtensionsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(int.MaxValue)]
        public void MillisecondsInt_ShouldCreateTimeSpanWithSpecifiedMilliseconds(int ms) =>
            ms.Ms().TotalMilliseconds.Should().Be(ms);
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void MillisecondsLong_ShouldCreateTimeSpanWithSpecifiedMilliseconds(long ms) =>
            ms.Ms().TotalMilliseconds.Should().Be(ms);
        
        [Theory]
        [InlineData(0.0f)]
        [InlineData(1.0f)]
        [InlineData(2.0f)]
        public void MillisecondsFloat_ShouldCreateTimeSpanWithSpecifiedMilliseconds(float ms) =>
            ms.Ms().TotalMilliseconds.Should().Be(ms);
        
        [Theory]
        [InlineData(0.0)]
        [InlineData(1.0)]
        [InlineData(2.0)]
        public void MillisecondsDouble_ShouldCreateTimeSpanWithSpecifiedMilliseconds(double ms) =>
            ms.Ms().TotalMilliseconds.Should().Be(ms);
    }
}