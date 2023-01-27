using System;
using System.Collections;
using System.Collections.Generic;
using Depra.Common.Extensions.Reflection;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Reflection;

public sealed partial class TypeExtensionsTests
{
    public class New
    {
        [Fact]
        public void New_ShouldThrow_IfSelfIsUnconstructedGenericType() =>
            Assert.Throws<ArgumentException>(() => typeof(HashSet<>).New());

        [Fact]
        public void New_List_AsNonGenericEnumerable_ShouldWork() =>
            typeof(List<string>).New<IEnumerable>().Should().BeOfType<List<string>>();

        [Fact]
        public void New_UnconstructedList_AsConstructedList_ShouldWork() =>
            typeof(List<>).New<List<string>>().Should().BeOfType<List<string>>();

        [Fact]
        public void New_UnconstructedList_AsConstructedEnumerableInterface_ShouldWork() =>
            typeof(List<>).New<IEnumerable<string>>().Should().BeOfType<List<string>>();

    }
}