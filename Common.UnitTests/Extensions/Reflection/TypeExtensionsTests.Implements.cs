using System;
using System.Collections;
using System.Collections.Generic;
using Depra.Common.Extensions.Reflection;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Reflection
{
    public sealed partial class TypeExtensionsTests
    {
        public class Implements
        {
            [Fact]
            public void Implements_ShouldBeFalse_IfTypeIsSelf() =>
                typeof(IAnimal).Implements<IAnimal>().Should().BeFalse();

            [Fact]
            public void Implements_ShouldBeTrue_IfTypeImplementsInterface()
            {
                Assert.True(typeof(Human).Implements(typeof(IAnimal)));
                Assert.True(typeof(Human).Implements(typeof(IOrganism)));

                Assert.True(typeof(Woman).Implements(typeof(IAnimal)));
                Assert.True(typeof(Woman).Implements(typeof(IOrganism)));
            }

            [Fact]
            public void Implements_ShouldBeFalse_IfTypeDoesntImplementsInterface()
            {
                Assert.False(typeof(Human).Implements(typeof(IEnumerable<>)));
                Assert.False(typeof(Woman).Implements(typeof(ICollection)));
                Assert.False(typeof(Woman).Implements(typeof(ICollection<>)));
                Assert.False(typeof(Woman).Implements(typeof(IEnumerable<int>)));
            }

            [Fact]
            public void Implements_ShouldBeTrue_IfGenericTypeImplementsInterface()
            {
                Assert.True(typeof(HashSet<int>).Implements(typeof(IEnumerable<>)));
                Assert.True(typeof(HashSet<>).Implements(typeof(IEnumerable<>)));
                Assert.True(typeof(List<>).Implements(typeof(IEnumerable<>)));
                Assert.True(typeof(Dictionary<,>).Implements(typeof(IEnumerable<>)));
            }

            [Fact]
            public void Implements_ShouldThrow_IfSpecifiedTypeIsNotInterface() =>
                Assert.Throws<InvalidOperationException>(() => typeof(Woman).Implements(typeof(Human)));

        }
    }
}