using System;
using System.Diagnostics.CodeAnalysis;
using Depra.Common.System.Equality;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Depra.Common.UnitTests.System.Equality;

public sealed class FuncEqualityComparerTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 0)]
    [InlineData(1, 10)]
    public void Equals_ShouldCallFunc(int a, int b)
    {
        var func = Substitute.For<Func<int, int, bool>>();
        var comparer = new FuncEqualityComparer<int>(func);

        var _ = comparer.Equals(a, b);

        func.Received(1).Invoke(a, b);
    }

    [Fact]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public void Constructor_ShouldThrowArgumentNullException_IfFuncIsNull()
    {
        // Arrange.
        Func<int, int, bool> func = null;
        
        // Act.
        var act = () => new FuncEqualityComparer<int>(func);
        
        // Assert.
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GetHashCode_ShouldCallInnerGetHashCode()
    {
        var comparer = new FuncEqualityComparer<object>((_, _) => true);
        var str = Substitute.For<object>();

        var _ = comparer.GetHashCode(str);

        str.Received(1).GetHashCode();
    }
}