using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Common.Extensions.Collections;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class MinBy
        {
            [Fact]
            public void MinBy_ShouldThrowException() =>
                Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Item>)null).MinBy(x => x.Number));

            [Fact]
            public void MinBy_ShouldThrowException_IfFuncIsNull() =>
                Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<int>().MinBy<int, Item>(null));

            [Fact]
            public void MinBy_ShouldReturnMinObject()
            {
                var items = new List<Item>(Enumerable.Range(0, 10).Select(x => new Item(x)));

                var minValue = items.Min(x => x.Number);
                var min = items.MinBy(x => x.Number);

                Assert.Equal(minValue, min.Number);
            }

            [Fact]
            public void MinBy_ShouldReturnMinObject_IfIComparable()
            {
                var items = new List<Item>(Enumerable.Range(0, 10).Select(x => new Item(x)));

                var a = items.Min(x => x);
                var b = items.MinBy(x => x);

                Assert.Same(a, b);
            }

            [Fact]
            public void MinBy_ShouldReturnCorrectReference()
            {
                var secondItem = new Item(2);
                var items = new List<Item>
                {
                    new Item(3),
                    new Item(2),
                    secondItem
                };

                Assert.NotSame(secondItem, items.MinBy(x => x.Number));
            }
        }
    }
}