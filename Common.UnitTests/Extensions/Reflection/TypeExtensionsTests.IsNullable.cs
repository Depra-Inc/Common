using System;
using Depra.Common.Extensions.Reflection;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Reflection;

public sealed partial class TypeExtensionsTests
{
    public class IsNullable
    {
        [Theory]
        [InlineData(typeof(int?))]
        [InlineData(typeof(long?))]
        [InlineData(typeof(short?))]
        [InlineData(typeof(byte?))]
        [InlineData(typeof(double?))]
        public void IsNullable_ShouldBeTrue_IfTypeIsNullable(Type type) => Assert.True(type.IsNullable());
    }
}