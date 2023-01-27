using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed partial class EnumerableExtensionsTests
{
    public class IsNullOrEmpty
    {
        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void IsNullOrEmpty_ShouldBeTrue_IfEnumerableIsNull()
        {
            // Arrange.
            var items = (IEnumerable<int>)null;
            
            // Act.
            var isNullOrEmpty = items.IsNullOrEmpty();
            
            // Assert.
            isNullOrEmpty.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_ShouldBeTrue_IfEnumerableIsEmpty()
        {
            // Arrange.
            var items = Enumerable.Empty<int>();
            
            // Act.
            var isNullOrEmpty = items.IsNullOrEmpty();
            
            // Assert.
            isNullOrEmpty.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_ShouldBeFalse_IfEnumerableIsNotEmpty()
        {
            // Arrange.
            var items = new[] { 1, 2, 3 };
            
            // Act.
            var isNullOrEmpty = items.IsNullOrEmpty();
            
            // Assert.
            isNullOrEmpty.Should().BeFalse();
        }
    }
}