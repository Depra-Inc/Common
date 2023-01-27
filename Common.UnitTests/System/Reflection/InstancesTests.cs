using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Depra.Common.System.Reflection;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.System.Reflection;

public class InstancesTests
{
    [Fact]
    public void InstancesOf_IInterface_ShouldBeAllImplementations() =>
        Instances.Of<IInterface>()
            .InCurrentAssembly()
            .Select(x => x.GetType())
            .Should()
            .BeEquivalentTo(new[]
            {
                typeof(Implementation1),
                typeof(Implementation2),
                typeof(Implementation3),
                typeof(Implementation4),
                typeof(Implementation5),
                typeof(ChildAndImplementation1),
                typeof(ChildAndImplementation2),
                typeof(ChildAndImplementation3),
                typeof(ChildAndImplementation4),
                typeof(ChildAndImplementation5),
            });

    [Fact]
    public void InstancesOf_Class_ShouldBeAllChilds() =>
        Instances.Of<Class>()
            .InCurrentAssembly()
            .Select(x => x.GetType())
            .Should()
            .BeEquivalentTo(new[]
            {
                typeof(Child1),
                typeof(Child2),
                typeof(Child3),
                typeof(Child4),
                typeof(Child5),
                typeof(ChildAndImplementation1),
                typeof(ChildAndImplementation2),
                typeof(ChildAndImplementation3),
                typeof(ChildAndImplementation4),
                typeof(ChildAndImplementation5),
            });

    [Fact]
    public void InstancesOf_ConstructedGenericInterface_ShouldBeConstructed() =>
        Instances.Of<IGenericInterface<string>>()
            .InCurrentAssembly()
            .Select(x => x.GetType())
            .Should()
            .BeEquivalentTo(new[]
            {
                typeof(GenericImplementation<string>),
                typeof(ConstructedGenericImplementation)
            });

    private interface IInterface { }

    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    private interface IGenericInterface<T> { }

    private abstract class Class { }

    [SuppressMessage("ReSharper", "UnusedType.Local")]
    private abstract class AbstractChild : Class { }

    private class Implementation1 : IInterface { }

    private class Implementation2 : IInterface { }

    private class Implementation3 : IInterface { }

    private class Implementation4 : IInterface { }

    private class Implementation5 : IInterface { }

    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    public class GenericImplementationThatShouldNotBeCreated<T> : IInterface { }

    private class GenericImplementation<T> : IGenericInterface<T> { }

    private class ConstructedGenericImplementation : IGenericInterface<string> { }

    private class Child1 : Class { }

    private class Child2 : Class { }

    private class Child3 : Class { }

    private class Child4 : Class { }

    private class Child5 : Class { }

    private class ChildAndImplementation1 : Class, IInterface { }

    private class ChildAndImplementation2 : Class, IInterface { }

    private class ChildAndImplementation3 : Class, IInterface { }

    private class ChildAndImplementation4 : Class, IInterface { }

    private class ChildAndImplementation5 : Class, IInterface { }
}