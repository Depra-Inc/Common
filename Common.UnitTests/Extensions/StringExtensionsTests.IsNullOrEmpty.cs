using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions
{
    public sealed partial class StringExtensionsTests
    {
        public class IsNullOrEmpty
        {
            [Theory]
            [InlineData("1")]
            [InlineData("2")]
            [InlineData("Hello")]
            public void IsNullOrEmpty_ShouldBeFalse_IfStringIsNotNullOrEmpty(string value) =>
                value.IsNullOrEmpty().Should().BeFalse();

            [Fact]
            public void IsNullOrEmpty_ShouldBeTrue_IfStringIsNull() =>
                ((string)null).IsNullOrEmpty().Should().BeTrue();

            [Fact]
            public void IsNullOrEmpty_ShouldBeTrue_IfStringIsEmpty() =>
                "".IsNullOrEmpty().Should().BeTrue();
        }
    }
}