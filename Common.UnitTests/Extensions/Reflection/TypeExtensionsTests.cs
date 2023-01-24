namespace Depra.Common.UnitTests.Extensions.Reflection
{
    public sealed partial class TypeExtensionsTests
    {
        public interface IAnimal { }
        public interface IOrganism { }

        public class Human : IAnimal, IOrganism { }
        public class Man : Human { }
        public class Woman : Human { }
        public class John : Man { }
        public class Jannet : Woman { }

        public class Item { public class Nested { public class Again { } } }
        
        public class GenericParent<T> { }
        public class GenericChild<T> : GenericParent<T> { }
        public class GenericGrandChild<T> : GenericChild<T> { }
        public class ConcreteChild : GenericChild<int> { }
        public struct GenericStruct<T> { }
    }
}