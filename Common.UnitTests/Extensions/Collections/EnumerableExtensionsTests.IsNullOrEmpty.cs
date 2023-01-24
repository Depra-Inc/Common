using System.Collections.Generic;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class IsNullOrEmpty
        {
            [Fact]
            public void IsNullOrEmpty_ShouldBeTrue_IfEnumerableIsNull() =>
                ((IEnumerable<int>)null).IsNullOrEmpty().Should().BeTrue();

            [Fact]
            public void IsNullOrEmpty_ShouldBeTrue_IfEnumerableIsEmpty() =>
                Enumerable.Empty<int>().IsNullOrEmpty().Should().BeTrue();

            [Fact]
            public void IsNullOrEmpty_ShouldBeFalse_IfEnumerableIsNotEmpty() =>
                new[] { 1, 2, 3 }.IsNullOrEmpty().Should().BeFalse();
        }
    }
}