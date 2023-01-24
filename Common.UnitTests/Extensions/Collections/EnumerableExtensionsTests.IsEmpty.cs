using System.Collections.Generic;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class IsEmpty
        {
            [Fact]
            public void IsEmpty_ShouldBeTrue_IfEnumerableIsEmpty() =>
                Enumerable.Empty<int>().IsEmpty().Should().BeTrue();

            [Fact]
            public void IsEmpty_ShouldBeTrue_IfArrayIsEmpty() =>
                "".IsEmpty().Should().BeTrue();

            [Fact]
            public void IsEmpty_ShouldBeTrue_IfLinkedListIsEmpty() =>
                new LinkedList<int>().IsEmpty().Should().BeTrue();

            [Fact]
            public void IsEmpty_ShouldBeFalse_IfEnumerableIsNotEmpty() =>
                Enumerable.Range(0, 1).IsEmpty().Should().BeFalse();

            [Fact]
            public void IsEmpty_ShouldBeFalse_IfArrayIsNotEmpty() =>
                "1".IsEmpty().Should().BeFalse();

            [Fact]
            public void IsEmpty_ShouldBeFalse_IfLinkedListIsNotEmpty() =>
                new LinkedList<int>(new[] { 1 }).IsEmpty().Should().BeFalse();
        }
    }
}