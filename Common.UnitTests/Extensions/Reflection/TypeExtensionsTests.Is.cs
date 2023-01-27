using System;
using System.Collections.Generic;
using Depra.Common.Extensions.Reflection;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Reflection;

public sealed partial class TypeExtensionsTests
{
    public class Is
    {
        [Theory]
        [InlineData(typeof(int), typeof(int))]
        [InlineData(typeof(IEnumerable<>), typeof(IEnumerable<>))]
        [InlineData(typeof(IEnumerable<int>), typeof(IEnumerable<int>))]
        public void Is_ShouldBeTrue_IfTypesAreEqual(Type a, Type b) =>
            Assert.True(a.Is(b));

        [Theory]
        [InlineData(typeof(int), typeof(double))]
        [InlineData(typeof(HashSet<>), typeof(List<>))]
        [InlineData(typeof(HashSet<int>), typeof(List<int>))]
        public void Is_ShouldBeFalse_IfTypesAreNotEqual(Type a, Type b) =>
            Assert.False(a.Is(b));

        [Theory]
        [InlineData(typeof(List<int>), typeof(List<>))]
        [InlineData(typeof(Dictionary<int, string>), typeof(Dictionary<,>))]
        public void Is_ShouldBeTrue_IfSecondIsGenericDefinitionOfFirst(Type a, Type b) =>
            Assert.True(a.Is(b));

        [Theory]
        [InlineData(typeof(int), typeof(List<>))]
        [InlineData(typeof(HashSet<int>), typeof(List<>))]
        [InlineData(typeof(IEnumerable<int>), typeof(List<>))]
        public void Is_ShouldBeFalse_IfSecondIsNotGenericDefinitionOfFirst(Type a, Type b) =>
            Assert.False(a.Is(b));
    }
}