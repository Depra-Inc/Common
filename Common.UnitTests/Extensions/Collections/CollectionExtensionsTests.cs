using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Depra.Common.Extensions;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed class CollectionExtensionsTests
    {
        [Fact]
        public void AddRange_ShouldThrow_IfSelfIsNull()
        {
            // Arrange.
            var range = Of(1, 2, 3);
            
            // Act.
            Action act = () => Null().AddRange(range);
            
            // Assert.
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddRange_ShouldThrow_IfOtherIsNull()
        {
            // Arrange.
            var nullRange = Null();
            
            // Act.
            Action act = () => New().AddRange(nullRange);
            
            // Assert.
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddRange_ShouldAddAllElementsToCollection()
        {
            // Arrange.
            IEnumerable<int> expectation;
            var elements = expectation = new[] { 1, 2, 3 };
            
            // Act.
            var actual =  Add(elements, to: New());
            
            // Assert.
            actual.Should().BeEquivalentTo(expectation);
        }

        private static ICollection<int> Null() => null;
        private static ICollection<int> New() => new List<int>();
        private static IEnumerable<int> Of(params int[] args) => args;

        [SuppressMessage("ReSharper", "ReturnTypeCanBeEnumerable.Local")]
        private static ICollection<int> Add(IEnumerable<int> items, ICollection<int> to) =>
            to.Do(x => x.AddRange(items));
    }
}