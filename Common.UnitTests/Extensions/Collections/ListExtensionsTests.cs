using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed class ListExtensionsTests
{
    [Theory]
    [InlineData(new string[0], "[]")]
    [InlineData(new[] { "1" }, "[ 1 ]")]
    [InlineData(new[] { "1", "2" }, "[ 1, 2 ]")]
    [InlineData(new[] { "1", "2", "3", "4", "5" }, "[ 1, 2, 3, 4, 5 ]")]
    [InlineData(new[] { "1", null, "3" }, "[ 1, null, 3 ]")]
    public void AsString_ShouldConvertListCorrectly(string[] array, string expected) =>
        array.ToList().AsString().Should().Be(expected);
}