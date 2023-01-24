using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public sealed partial class EnumerableExtensionsTests
    {
        public class Each
        {
            [Fact]
            public void Each_ShouldThrow_IfSelfIsNull()
            {
                // Arrange.
                IEnumerable<int> numbers = null;

                // Act.
                Action act = () => numbers.Each(x => { });

                // Assert.
                act.Should().Throw<ArgumentNullException>();
            }

            [Fact]
            public void Each_ShouldInvokeActionOnElements_IfEnumerableIsCollapsed()
            {
                // Arrange.
                var sideNumbers = new List<int>();

                // Act.
                var numbers = Enumerable
                    .Range(0, 10)
                    .Each(x => sideNumbers.Add(x))
                    .ToList();

                // Assert.
                numbers.Should().Equal(sideNumbers);
            }

            [Fact]
            public void Each_ShouldInvokeActionOnElements_IfEnumerableIsCollapsedAndFiltered()
            {
                // Arrange.
                var sideNumbers = new List<int>();

                // Act.
                var numbers = Enumerable
                    .Range(0, 10)
                    .Where(x => x > 5)
                    .Each(x => sideNumbers.Add(x))
                    .ToList();

                // Assert.
                numbers.Should().Equal(sideNumbers);
            }

            [Fact]
            public void Each_ShouldInvokeActionOnElements_IfEnumerableIsCollapsedButFilteredLater()
            {
                // Arrange.
                var sideNumbers = new List<int>();

                // Act.
                var numbers = Enumerable
                    .Range(0, 10)
                    .Each(x => sideNumbers.Add(x))
                    .Where(x => x > 5)
                    .ToList();

                // Assert.
                numbers.Should().NotEqual(sideNumbers);
                sideNumbers.Should().Equal(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            }

            [Fact]
            [SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
            public void Each_ShouldNotInvokeActionOnElements_IfEnumerableIsNotCollapsed()
            {
                // Arrange.
                var sideNumbers = new List<int>();

                // Act.
                Enumerable
                    .Range(0, 10)
                    .Each(x => sideNumbers.Add(x))
                    .Where(x => x > 5);

                // Assert.
                sideNumbers.Should().BeEmpty();
            }
        }
    }
}