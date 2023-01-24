using System;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        [Fact]
        public void ExceptWithFunc_ShouldExcludeItemsUsingFunc()
        {
            // Arrange.
            var a = Enumerable.Range(0, 10);
            var b = Enumerable.Range(5, 10);
            var example = Enumerable.Range(0, 5);

            // Act.
            var exceptElements = a.Except(b, (x, y) => x == y);
            
            // Assert.
            exceptElements.Should().BeEquivalentTo(example);
        }

        [Fact]
        public void DistinctWithFunc_ShouldFilterItemsAsLinq()
        {
            // Arrange.
            var items = new[] { 1, 2, 3, 4 };
            var example = items.Distinct();
            
            // Act.
            var distinctElements = items.Distinct((x, y) => x == y);

            // Assert.
            distinctElements.Should().BeEquivalentTo(example);
        }

        private class Item : IComparable<Item>
        {
            public readonly int Number;

            public Item(int number) => Number = number;

            public int CompareTo(Item other)
            {
                if (ReferenceEquals(this, other))
                {
                    return 0;
                }

                return ReferenceEquals(null, other) ? 1 : Number.CompareTo(other.Number);
            }
        }
    }
}