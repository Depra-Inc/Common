using Depra.Common.System;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.System;

public sealed class EnumOfTests
{
    [Fact]
    public void Values_ReturnsAllEnumValuesAsArray() =>
        EnumOf<Order>.Values
            .Should().BeEquivalentTo(new[] 
            { 
                Order.First, 
                Order.Second, 
                Order.Third, 
            });

    [Fact]
    public void From_ReturnsEnumValue_IfStringDoesMatch() =>
        EnumOf<Order>.From("First").Should().Be(Order.First);

    [Fact]
    public void From_ReturnsNull_IfStringDoesNotMatch() =>
        EnumOf<Order>.From("").Should().BeNull();

    private enum Order
    {
        First,
        Second,
        Third,
    }
}