using Depra.Common.Extensions;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions;

public sealed class NullableExtensionsTests
{
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("Hello")]
    [InlineData("World")]
    public void Or_ShouldReturnSelf_IfItIsNotNull(string value) =>
        value.Or("1").Should().BeEquivalentTo(value);

    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("Hello")]
    [InlineData("World")]
    public void Or_ShouldReturnDefaultValue_IfSelfIsNull(string def) =>
        ((string) null).Or(def).Should().BeEquivalentTo(def);

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void OrDefault_ShouldReturnSelf_IfItIsNotNull(int value) =>
        new int?(value).OrDefault().Should().Be(value);


    [Fact]
    public void OrDefault_ShouldReturnDefaultValue_IfSelfIsNull() =>
        ((int?) null).OrDefault().Should().Be(0);
}