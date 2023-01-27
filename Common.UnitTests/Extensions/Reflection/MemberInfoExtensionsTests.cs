using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Depra.Common.Extensions.Reflection;
using Xunit;
using static FluentAssertions.AssertionExtensions;

namespace Depra.Common.UnitTests.Extensions.Reflection;

public sealed class MemberInfoExtensionsTests
{
    [Fact]
    public void AttributesCountOfEmptyType_ShouldBe0() =>
        AttributesCount(typeof(EmptyType)).Should().Be(0);

    [Fact]
    public void AttributesCountOfSomeType_ShouldBe3() =>
        AttributesCount(typeof(SomeType)).Should().Be(3);

    private static int AttributesCount(Type type) =>
        type.Fields().Count(x => x.Has<SomeAttribute>()) +
        type.Properties().Count(x => x.Has<SomeAttribute>()) +
        type.Methods().Count(x => x.Has<SomeAttribute>());

    private class SomeAttribute : Attribute { }

    private class EmptyType { }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private class SomeType
    {
#pragma warning disable CS0649
        [Some] public int Field;
#pragma warning restore CS0649
        [Some] public int Property => 0;

        [Some]
        public void Method() { }
    }
}