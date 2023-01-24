using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class NextTo
        {
            [Fact]
            public void NextTo_ShouldReturnSecondItem_IfFirstIsSpecified() =>
                new[] { "1", "2", "3" }.NextTo("1").Should().Be("2");

            [Fact]
            public void NextTo_ShouldReturnThirdItem_IfSecondIsSpecified() =>
                new[] { "1", "2", "3" }.NextTo("2").Should().Be("3");

            [Fact]
            public void NextTo_ShouldReturnNull_IfThirdIsSpecified() =>
                new[] { "1", "2", "3" }.NextTo("3").Should().Be(null);
        }
    }
}