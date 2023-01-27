using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed partial class EnumerableExtensionsTests
{
    public class OrEmpty
    {
        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void OrEmpty_ShouldReturnEmptyEnumerable_IfSelfIsNull()
        {
            // Arrange.
            var items = (IEnumerable<string>)null;
            
            // Act.
            items = items.OrEmpty();
            
            // Assert.
            items.Should().BeEmpty();
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void OrEmpty_ShouldReturnSelf_IfSelfIsNotNull()
        {
            // Arrange.
            var enumerable = Enumerable.Range(0, 5);
                
            // Act.
            var emptyOrSelf = enumerable.OrEmpty();
                
            // Assert.
            emptyOrSelf.Should().BeSameAs(enumerable);
        }
    }
}