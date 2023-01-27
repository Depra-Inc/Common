using Depra.Common.Extensions;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions;

public sealed class ComparableExtensionsTests
{
    [Theory]
    [InlineData(0, 10)]
    [InlineData(0, 9)]
    [InlineData(0, 100)]
    [InlineData(-10, -9)]
    public void ButNotLess_ShouldReturnSecondValue_IfFirstIsLessThanSecond(int first, int second) =>
        first.ButNotLess(than: second).Should().Be(second);
      
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(2, 0)]
    [InlineData(10, 0)]
    [InlineData(15, 0)]
    public void ButNotLess_ShouldReturnFirstValue_IfFirstIsGreaterThanSecond(int first, int second) =>
        first.ButNotLess(than: second).Should().Be(first);
      
    [Fact]
    public void ButNotLess_ShouldReturnFirstValue_IfFirstIsEqualToSecond() =>
        1.ButNotLess(than: 1).Should().Be(1);

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(2, 0)]
    [InlineData(10, 0)]
    [InlineData(15, 0)]
    public void ButNotGreater_ShouldReturnSecondValue_IfFirstIsGreaterThanSecond(int first, int second) =>
        first.ButNotGreater(than: second).Should().Be(second);

    [Theory]
    [InlineData(0, 10)]
    [InlineData(0, 9)]
    [InlineData(0, 100)]
    [InlineData(-10, -9)]
    public void ButNotGreater_ShouldReturnFirstValue_IfFirstIsLessThanSecond(int first, int second) =>
        first.ButNotGreater(than: second).Should().Be(first);
}