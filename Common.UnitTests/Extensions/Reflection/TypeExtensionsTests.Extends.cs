using System;
using System.Collections.Generic;
using Depra.Common.Extensions.Reflection;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Reflection
{
    public sealed partial class TypeExtensionsTests
    {
        public class Extends
        {
            [Fact]
            public void Extends_ShouldBeFalse_IfTypeIsSelf() =>
                typeof(Human).Extends<Human>().Should().BeFalse();

            [Fact]
            public void Extends_ShouldBeTrue_IfTypeExtendsClass()
            {
                Assert.True(typeof(Man).Extends(typeof(Human)));
                Assert.True(typeof(Woman).Extends(typeof(Human)));
                Assert.True(typeof(John).Extends(typeof(Human)));
                Assert.True(typeof(Jannet).Extends(typeof(Human)));
            }

            [Fact]
            public void Extends_ShouldBeFalse_IfTypeDoesntExtendsClass()
            {
                Assert.False(typeof(Man).Extends(typeof(Woman)));
                Assert.False(typeof(Woman).Extends(typeof(Man)));
                Assert.False(typeof(John).Extends(typeof(List<>)));
                Assert.False(typeof(Jannet).Extends(typeof(List<int>)));
                Assert.False(typeof(Jannet).Extends(typeof(HashSet<>)));
            }

            [Fact]
            public void Extends_ShouldBeTrue_IfGenericTypeExtendsClass()
            {
                Assert.True(typeof(GenericChild<int>).Extends(typeof(GenericParent<>)));
                Assert.True(typeof(GenericChild<>).Extends(typeof(GenericParent<>)));

                Assert.True(typeof(GenericGrandChild<int>).Extends(typeof(GenericParent<>)));
                Assert.True(typeof(GenericGrandChild<>).Extends(typeof(GenericParent<>)));
                Assert.True(typeof(ConcreteChild).Extends(typeof(GenericChild<>)));
            }

            [Fact]
            public void Extends_ShouldThrow_IfSpecifiedTypeIsNotClass() =>
                Assert.Throws<InvalidOperationException>(() => typeof(Woman).Extends(typeof(IAnimal)));
        }
    }
}