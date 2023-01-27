using System;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed partial class EnumerableExtensionsTests
{
    public class Second
    {
        [Fact]
        public void Second_ShouldThrowInvalidOperationException_IfEnumerableIsEmpty()
        {
            // Arrange.
            var items = Enumerable.Empty<int>();

            // Act.
            var act = () => items.Second();

            // Assert.
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Second_ShouldThrowInvalidOperationException_IfEnumerableHasOneElement()
        {
            // Arrange.
            var items = new[] { 1 };

            // Act.
            var act = () => items.Second();

            // Assert.
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Second_ShouldReturnSecondElementOfEnumerable()
        {
            // Arrange.
            var items = new[] { 100, 200, 300 };

            // Act.
            var secondItem = items.Second();

            // Assert.
            secondItem.Should().Be(200);
        }
    }
}