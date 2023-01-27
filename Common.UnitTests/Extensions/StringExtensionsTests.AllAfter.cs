using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions;

public sealed partial class StringExtensionsTests
{
    public class AllAfter
    {
        [Fact]
        public void AllAfter_ShouldNotChangeString_IfThereIsNoPart() =>
            "Hello".AllAfter("s").Should().Be("Hello");

        [Theory]
        [InlineData("Hello", "H", "ello")]
        [InlineData("Hello", "He", "llo")]
        [InlineData("Hello", "Hel", "lo")]
        [InlineData("Hello", "Hell", "o")]
        [InlineData("Hello", "Hello", "")]
        public void AllAfter_ShouldReturnTextAfterSpecifiedPart(string source, string part, string expected) =>
            source.AllAfter(part).Should().Be(expected);
    }
}