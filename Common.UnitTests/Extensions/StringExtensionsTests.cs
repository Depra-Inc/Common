#nullable enable
using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions
{
    public sealed class StringExtensionsTests
    {
        #region IsNullOrEmpty
        
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("Hello")]
        public void IsNullOrEmpty_ShouldBeFalse_IfStringIsNotNullOrEmpty(string value) =>
            value.IsNullOrEmpty().Should().BeFalse();
        
        [Fact]
        public void IsNullOrEmpty_ShouldBeTrue_IfStringIsNull() =>
            ((string) null).IsNullOrEmpty().Should().BeTrue();
        
        [Fact]
        public void IsNullOrEmpty_ShouldBeTrue_IfStringIsEmpty() =>
            "".IsNullOrEmpty().Should().BeTrue();
        
        #endregion

        #region Or

        [Fact]
        public void Or_ShouldBeSelf_IfStringIsNotNull() =>
            "Hello".Or("1").Should().Be("Hello");

        [Fact]
        public void Or_ShouldBeDefault_IfStringIsNull() =>
            ((string) null).Or("Hello").Should().Be("Hello");

        #endregion

        #region Map

        [Fact]
        public void MapOfCharToString_ShouldReplaceEveryCharacterWithOther() =>
            "1234".Map(x => '*').Should().Be("****");

        [Fact]
        public void MapOfCharToString_ShouldReplaceEveryCharacterWithString() =>
            "1234".Map(x => "**").Should().Be("********");

        #endregion

        #region Without

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
        public void WithoutCharAt_ShouldRemoveCharacterAtSpecifiedPosition(string source, int index, string expected) =>
            source.Without(charAt: index).Should().Be(expected);

        [Theory]
        [InlineData("Test", 0, "est")]
        [InlineData("Test", 1, "Tst")]
        [InlineData("Test", 2, "Tet")]
        [InlineData("Test", 3, "Tes")]
        public void WithoutCharAt_UsingBuffer_ShouldRemoveCharacterAtSpecifiedPosition(string source, int index, string expected)
        {
            var buffer = new char[100];
            
            source.Without(charAt: index, @using: buffer).Should().Be(expected);
        }

        #endregion

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