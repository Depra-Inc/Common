using System;
using System.Collections.Generic;
using System.Reflection;
using Depra.Common.Extensions.Reflection;
using FluentAssertions;
using Xunit;
using static Depra.Common.UnitTests.Extensions.Reflection.TypeExtensionsTests.Common;

namespace Depra.Common.UnitTests.Extensions.Reflection;

public sealed partial class TypeExtensionsTests
{
    public class PrettyName
    {
        [Fact]
        public void PrettyName_ShouldReturnTypeName_IfTypeIsNonGeneric() =>
            typeof(Man).PrettyName().Should().Be("Man");

        [Fact]
        public void PrettyNameWithDeclaringType_ShouldReturnFullTypeName_IfTypeIsNested() =>
            typeof(Item.Nested).PrettyName(asNested: true).Should().Be("TypeExtensionsTests.Common.Item.Nested");

        [Fact]
        public void PrettyNameWithDeclaringType_ShouldReturnFullTypeName_IfTypeIsDoubleNested() =>
            typeof(Item.Nested.Again).PrettyName(asNested: true).Should()
                .Be("TypeExtensionsTests.Common.Item.Nested.Again");

        [Theory]
        [InlineData(typeof(int?), "int?")]
        [InlineData(typeof(BindingFlags?), "BindingFlags?")]
        [InlineData(typeof(DateTime?), "DateTime?")]
        [InlineData(typeof(GenericStruct<int>?), "GenericStruct<int>?")]
        [InlineData(typeof(GenericStruct<int?>?), "GenericStruct<int?>?")]
        public void PrettyName_ShouldReturnShortTypeName_IfTypeIsNullable(Type type, string name) =>
            type.PrettyName().Should().Be(name);

        [Theory]
        [InlineData(typeof(IEnumerable<bool>), "IEnumerable<bool>")]
        [InlineData(typeof(IEnumerable<byte>), "IEnumerable<byte>")]
        [InlineData(typeof(IEnumerable<sbyte>), "IEnumerable<sbyte>")]
        [InlineData(typeof(IEnumerable<short>), "IEnumerable<short>")]
        [InlineData(typeof(IEnumerable<ushort>), "IEnumerable<ushort>")]
        [InlineData(typeof(IEnumerable<int>), "IEnumerable<int>")]
        [InlineData(typeof(IEnumerable<uint>), "IEnumerable<uint>")]
        [InlineData(typeof(IEnumerable<long>), "IEnumerable<long>")]
        [InlineData(typeof(IEnumerable<ulong>), "IEnumerable<ulong>")]
        [InlineData(typeof(IEnumerable<float>), "IEnumerable<float>")]
        [InlineData(typeof(IEnumerable<double>), "IEnumerable<double>")]
        [InlineData(typeof(IEnumerable<decimal>), "IEnumerable<decimal>")]
        [InlineData(typeof(IEnumerable<string>), "IEnumerable<string>")]
        [InlineData(typeof(IEnumerable<object>), "IEnumerable<object>")]
        public void
            PrettyName_ShouldReturnTypeNameWithGenericParameters_IfTypeIsConstructedGenericAndOneParameterIsUsed(
                Type type, string expected) =>
            type.PrettyName().Should().Be(expected);

        [Fact]
        public void
            PrettyName_ShouldReturnTypeNameWithGenericParameters_IfTypeIsUnconstructedGenericAndOneParameterIsUsed() =>
            typeof(IEnumerable<>).PrettyName().Should().Be("IEnumerable<T>");

        [Fact]
        public void
            PrettyName_ShouldReturnTypeNameWithGenericParameters_IfTypeIsConstructedGenericAndTwoParametersAreUsed() =>
            typeof(IDictionary<int, string>).PrettyName().Should().Be("IDictionary<int, string>");

        [Fact]
        public void
            PrettyName_ShouldReturnTypeNameWithGenericParameters_IfTypeIsUnconstructedGenericAndTwoParametersAreUsed() =>
            typeof(IDictionary<,>).PrettyName().Should().Be("IDictionary<TKey, TValue>");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArray() =>
            typeof(int[]).PrettyName().Should().Be("int[]");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArrayOfRankTwo() =>
            typeof(int[,]).PrettyName().Should().Be("int[,]");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArrayOfRankThree() =>
            typeof(int[,,]).PrettyName().Should().Be("int[,,]");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArrayOfArrays() =>
            typeof(int[][]).PrettyName().Should().Be("int[][]");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArrayOfArraysOfRankTwo() =>
            typeof(int[,][]).PrettyName().Should().Be("int[][,]");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArrayOfRankTwoOfArrays() =>
            typeof(int[][,]).PrettyName().Should().Be("int[,][]");

        [Fact]
        public void PrettyName_ShouldReturnCorrectTypeName_IfTypeIsArrayOfRankTwoOfArraysOfRankTwo() =>
            typeof(int[,][,]).PrettyName().Should().Be("int[,][,]");
    }
}