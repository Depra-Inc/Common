using System.Collections.Generic;
using System.Linq;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed partial class EnumerableExtensionsTests
    {
        public class OrEmpty
        {
            [Fact]
            public void OrEmpty_ShouldReturnEmptyEnumerable_IfSelfIsNull() =>
                ((IEnumerable<string>)null).OrEmpty().Should().BeEmpty();

            [Fact]
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
}