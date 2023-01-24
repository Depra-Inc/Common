using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions
{
    public sealed partial class StringExtensionsTests
    {
        public class Without
        {
            [Theory]
            [InlineData("Test", "T", "est")]
            [InlineData("Test", "Te", "st")]
            [InlineData("Test", "Tes", "t")]
            [InlineData("Test", "Test", "")]
            [InlineData("Test", "te", "Test")]
            [InlineData("Test", "123", "Test")]
            [InlineData("Test", "fasd", "Test")]
            public void WithoutPrefix_ShouldRemoveStartOfString(string source, string part, string expected) =>
                source.WithoutPrefix(part).Should().Be(expected);

            [Theory]
            [InlineData("Test", "t", "Tes")]
            [InlineData("Test", "st", "Te")]
            [InlineData("Test", "est", "T")]
            [InlineData("Test", "Test", "")]
            [InlineData("Test", "te", "Test")]
            [InlineData("Test", "123", "Test")]
            [InlineData("Test", "fasd", "Test")]
            public void WithoutSuffix_ShouldRemoveStartOfString(string source, string part, string expected) =>
                source.WithoutSuffix(part).Should().Be(expected);

            [Theory]
            [InlineData("Test", "es", "Tt")]
            [InlineData("TestTest", "es", "TtTt")]
            [InlineData("TestTest", "Test", "")]
            public void Without_ShouldReplacePartWithEmptyString(string source, string part, string expected) =>
                source.Without(part).Should().Be(expected);

            [Theory]
            [InlineData("Test", 0, "est")]
            [InlineData("Test", 1, "Tst")]
            [InlineData("Test", 2, "Tet")]
            [InlineData("Test", 3, "Tes")]
            public void WithoutCharAt_ShouldRemoveCharacterAtSpecifiedPosition(string source, int index,
                string expected) =>
                source.Without(charAt: index).Should().Be(expected);

            [Theory]
            [InlineData("Test", 0, "est")]
            [InlineData("Test", 1, "Tst")]
            [InlineData("Test", 2, "Tet")]
            [InlineData("Test", 3, "Tes")]
            public void WithoutCharAt_UsingBuffer_ShouldRemoveCharacterAtSpecifiedPosition(string source, int index,
                string expected)
            {
                // Arrange.
                var buffer = new char[100];

                // Act.
                var actual = source.Without(charAt: index, @using: buffer);

                // Assert.
                actual.Should().Be(expected);
            }
        }
    }
}