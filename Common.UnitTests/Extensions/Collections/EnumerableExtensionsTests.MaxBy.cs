using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed partial class EnumerableExtensionsTests
{
    public class MaxBy
    {
        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void MaxBy_ShouldThrowException()
        {
            // Arrange.
            var items = (IEnumerable<Item>)null;

            // Act.
            var act = () => EnumerableExtensions.MinBy(items, x => x.Number);

            // Assert.
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MaxBy_ShouldThrowException_IfFuncIsNull()
        {
            // Arrange.
            var items = Enumerable.Empty<int>();

            // Act.
            var act = () => EnumerableExtensions.MinBy<int, Item>(items, null);

            // Assert.
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MaxBy_ShouldReturnMaxObject()
        {
            // Arrange.
            var items = new List<Item>(Enumerable.Range(0, 10).Select(x => new Item(x)));

            // Act.
            var minValue = items.Max(x => x.Number);
            var min = EnumerableExtensions.MaxBy(items, x => x.Number);

            // Assert.
            min.Number.Should().Be(minValue);
        }

        [Fact]
        public void MaxBy_ShouldReturnMaxObject_IfIComparable()
        {
            // Arrange.
            var items = new List<Item>(Enumerable.Range(0, 10).Select(x => new Item(x)));

            // Act.
            var a = items.Max(x => x);
            var b = EnumerableExtensions.MaxBy(items, x => x);

            // Assert.
            b.Should().BeSameAs(a);
        }

        [Fact]
        public void MaxBy_ShouldReturnCorrectReference()
        {
            // Arrange.
            var secondItem = new Item(3);
            var items = new List<Item>
            {
                new Item(3),
                new Item(2),
                secondItem
            };

            // Act.
            var maxItem = EnumerableExtensions.MaxBy(items, x => x.Number);

            // Assert.
            maxItem.Should().NotBeSameAs(secondItem);
        }
    }
}