using System;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class Second
        {
            [Fact]
            public void Second_ShouldThrowInvalidOperationException_IfEnumerableIsEmpty() =>
                Assert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Second());

            [Fact]
            public void Second_ShouldThrowInvalidOperationException_IfEnumerableHasOneElement() =>
                Assert.Throws<InvalidOperationException>(() => new[] { 1 }.Second());

            [Fact]
            public void Second_ShouldReturnSecondElementOfEnumerable() =>
                new[] { 100, 200, 300 }.Second().Should().Be(200);
        }
    }
}