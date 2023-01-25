using Depra.Common.System.Threading;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.System.Threading
{
    public sealed class AtomicallyTests
    {
        [Theory]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, 2, 3, 3)]
        [InlineData(3, 3, 4, 4)]
        public void Change_ShouldReplaceValueWithTo_IfItIsEqualToFrom(int actual, int from, int to, int expected)
        {
            Atomically.Change(ref actual, from, to);
      
            actual.Should().Be(expected);
        }
    
        [Theory]
        [InlineData(1, 2, 3, 1)]
        [InlineData(2, 3, 4, 2)]
        [InlineData(3, 4, 5, 3)]
        public void Change_ShouldNotReplaceValueWithTo_IfItIsNotEqualToFrom(int actual, int from, int to, int expected)
        {
            Atomically.Change(ref actual, from, to);
      
            actual.Should().Be(expected);
        }
    
        [Theory]
        [InlineData(1, 1, 2, 1)]
        [InlineData(2, 2, 3, 2)]
        [InlineData(3, 3, 4, 3)]
        [InlineData(1, 2, 3, 1)]
        [InlineData(2, 3, 4, 2)]
        [InlineData(3, 4, 5, 3)]
        public void Change_ShouldReturnOldValueOfSelf(int actual, int from, int to, int expected) =>
            Atomically.Change(ref actual, from, to).Should().Be(expected);
    
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 3)]
        [InlineData(3, 3, 4)]
        public void Changed_ShouldBeTrue_IfValueWasChanged(int actual, int from, int to) =>
            Atomically.Changed(ref actual, from, to).Should().BeTrue();
    
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 4)]
        [InlineData(3, 4, 5)]
        public void Changed_ShouldBeFalse_IfValueWasNotChanged(int actual, int from, int to) =>
            Atomically.Changed(ref actual, from, to).Should().BeFalse();
    }
}