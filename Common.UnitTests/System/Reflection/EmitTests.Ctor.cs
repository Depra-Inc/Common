using System;
using Depra.Common.System.Reflection;
using Xunit;

namespace Depra.Common.UnitTests.System.Reflection
{
    public sealed partial class EmitTests
    {
        public class Ctor
        {
            [Fact]
            public void Ctor_ShouldThrowArgumentNullException_IfTypeHasNotEmptyCtor() =>
                Assert.Throws<ArgumentNullException>(Emit.Ctor<WithoutEmptyCtor>);

            [Fact]
            public void Ctor_ShouldCreateCorrectFunc_IfTypeHasEmptyCtor()
            {
                var func = Emit.Ctor<WithEmptyCtor>();

                Assert.NotNull(func());
            }

            [Fact]
            public void Ctor_ShouldCreateCorrectFunc_IfWasCalledManyTimes()
            {
                Emit.Ctor<WithEmptyCtor>();
                Emit.Ctor<WithEmptyCtor>();
                Emit.Ctor<WithEmptyCtor>();
                var func = Emit.Ctor<WithEmptyCtor>();

                Assert.NotNull(func());
            }

            [Fact]
            public void Ctor_ShouldCreateCorrectFunc_IfTypeHasManyCtors()
            {
                var func = Emit.Ctor<WithManyCtors>();

                Assert.NotNull(func());
            }

            private class WithoutEmptyCtor
            {
                public WithoutEmptyCtor(int a) { }
            }

            private class WithEmptyCtor { }

            private class WithManyCtors
            {
                public WithManyCtors(int a) { }
                public WithManyCtors(int a, int b) { }
                public WithManyCtors(string a) { }
                public WithManyCtors() { }
            }
        }
    }
}