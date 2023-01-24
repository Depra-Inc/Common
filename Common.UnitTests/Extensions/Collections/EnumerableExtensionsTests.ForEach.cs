using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class ForEach
        {
            [Fact]
            public void ForEach_ShouldThrow_IfSelfIsNull()
            {
                // Arrange.
                IEnumerable<int> numbers = null;

                // Act.
                Action act = () => numbers.ForEach(x => { });

                // Assert.
                act.Should().Throw<ArgumentNullException>();
            }

            [Fact]
            public void ForEach_ShouldInvokeActionOnElements()
            {
                // Arrange.
                var sideNumbers = new List<int>();
                var example = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                // Act.
                Enumerable
                    .Range(0, 10)
                    .ForEach(x => sideNumbers.Add(x));

                // Assert.
                sideNumbers.Should().BeEquivalentTo(example);
            }

            [Fact]
            public void ForEach_ShouldInvokeActionOnElements_IfEnumerableIsFiltered()
            {
                // Arrange.
                var sideNumbers = new List<int>();
                var example = new[] { 6, 7, 8, 9 };

                // Act.
                Enumerable
                    .Range(0, 10)
                    .Where(x => x > 5)
                    .ForEach(x => sideNumbers.Add(x));

                // Assert.
                sideNumbers.Should().BeEquivalentTo(example);
            }
        }
    }
}