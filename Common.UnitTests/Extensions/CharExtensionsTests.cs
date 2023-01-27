using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions;

public sealed class CharExtensionsTests
{
    [Theory]
    [InlineData('1', '1')]
    [InlineData('2', '2')]
    [InlineData('3', '3')]
    [InlineData('4', '4')]
    public void Is_ShouldReturnTrue_IfCharactersAreEqual(char a, char b) =>
        a.Is(b).Should().BeTrue();
        
    [Theory]
    [InlineData('1', '2')]
    [InlineData('2', '3')]
    [InlineData('3', '4')]
    [InlineData('4', '5')]
    public void Is_ShouldReturnFalse_IfCharactersAreNotEqual(char a, char b) =>
        a.Is(b).Should().BeFalse();
        
    [Theory]
    [InlineData('0')]
    [InlineData('1')]
    [InlineData('2')]
    [InlineData('3')]
    [InlineData('4')]
    [InlineData('5')]
    [InlineData('6')]
    [InlineData('7')]
    [InlineData('8')]
    [InlineData('9')]
    public void IsDigit_ShouldBeTrue_IfCharIsDigit(char ch) =>
        ch.IsDigit().Should().BeTrue();
        
    [Theory]
    [InlineData('`')]
    [InlineData('a')]
    [InlineData('\n')]
    [InlineData('\r')]
    [InlineData(')')]
    public void IsDigit_ShouldBeFalse_IfCharIsNotDigit(char ch) =>
        ch.IsDigit().Should().BeFalse();

    [Theory]
    [InlineData('a')]
    [InlineData('B')]
    [InlineData('w')]
    [InlineData('e')]
    [InlineData('D')]
    public void IsLetter_ShouldBeTrue_IfCharIsLetter(char ch) =>
        ch.IsLetter().Should().BeTrue();
        
    [Theory]
    [InlineData('1')]
    [InlineData(',')]
    [InlineData('-')]
    [InlineData('#')]
    [InlineData('\n')]
    public void IsLetter_ShouldBeFalse_IfCharIsNotLetter(char ch) =>
        ch.IsLetter().Should().BeFalse();
        
    [Theory]
    [InlineData('a')]
    [InlineData('1')]
    [InlineData('W')]
    [InlineData('4')]
    [InlineData('D')]
    public void IsLetter_ShouldBeTrue_IfCharIsLetterOrDigit(char ch) =>
        ch.IsLetterOrDigit().Should().BeTrue();
        
    [Theory]
    [InlineData(',')]
    [InlineData('-')]
    [InlineData('#')]
    [InlineData('\n')]
    public void IsLetter_ShouldBeFalse_IfCharIsNotLetterOrDigit(char ch) =>
        ch.IsLetterOrDigit().Should().BeFalse();
        
    [Theory]
    [InlineData(' ')]
    [InlineData('\n')]
    [InlineData('\r')]
    public void IsLetter_ShouldBeTrue_IfCharIsWhiteSpace(char ch) =>
        ch.IsWhitespace().Should().BeTrue();
        
    [Theory]
    [InlineData('a')]
    [InlineData('1')]
    [InlineData('-')]
    [InlineData('#')]
    public void IsLetter_ShouldBeFalse_IfCharIsNotWhiteSpace(char ch) =>
        ch.IsWhitespace().Should().BeFalse();
}