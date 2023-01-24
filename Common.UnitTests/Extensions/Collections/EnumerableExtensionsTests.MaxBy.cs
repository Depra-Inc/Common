using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Common.Extensions.Collections;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class MaxBy
        {
            [Fact]
            public void MaxBy_ShouldThrowException() =>
                Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Item>)null).MinBy(x => x.Number));

            [Fact]
            public void MaxBy_ShouldThrowException_IfFuncIsNull() =>
                Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<int>().MinBy<int, Item>(null));

            [Fact]
            public void MaxBy_ShouldReturnMaxObject()
            {
                var items = new List<Item>(Enumerable.Range(0, 10).Select(x => new Item(x)));

                var minValue = items.Max(x => x.Number);
                var min = items.MaxBy(x => x.Number);

                Assert.Equal(minValue, min.Number);
            }

            [Fact]
            public void MaxBy_ShouldReturnMaxObject_IfIComparable()
            {
                var items = new List<Item>(Enumerable.Range(0, 10).Select(x => new Item(x)));

                var a = items.Max(x => x);
                var b = items.MaxBy(x => x);

                Assert.Same(a, b);
            }

            [Fact]
            public void MaxBy_ShouldReturnCorrectReference()
            {
                var secondItem = new Item(3);
                var items = new List<Item>
                {
                    new Item(3),
                    new Item(2),
                    secondItem
                };

                Assert.NotSame(secondItem, items.MaxBy(x => x.Number));
            }
        }
    }
}