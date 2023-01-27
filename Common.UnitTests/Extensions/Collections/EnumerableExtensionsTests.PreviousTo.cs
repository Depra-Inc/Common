using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed partial class EnumerableExtensionsTests
{
    public class PreviousTo
    {
        [Fact]
        public void PreviousTo_ShouldReturnNull_IfFirstIsSpecified() =>
            new[] { "1", "2", "3" }.PreviousTo("1").Should().Be(null);

        [Fact]
        public void PreviousTo_ShouldReturnFirstItem_IfSecondIsSpecified() =>
            new[] { "1", "2", "3" }.PreviousTo("2").Should().Be("1");

        [Fact]
        public void PreviousTo_ShouldReturnSecondItem_IfThirdIsSpecified() =>
            new[] { "1", "2", "3" }.PreviousTo("3").Should().Be("2");
    }
}