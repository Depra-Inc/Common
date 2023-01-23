using System.Reflection;

namespace Depra.Common.Extensions.Reflection
{
    public static partial class TypeExtensions
    {
        /// <summary>
        /// Represents structure that allows building declarative expressions of different <see cref="BindingFlags"/> values.
        /// </summary>
        public readonly struct BindingSpecification
        {
            private readonly BindingFlags _flags;

            /// <summary>
            /// Initializes new instance of <see cref="BindingSpecification"/> with specified flags.
            /// </summary>
            /// <param name="flags">Initial <see cref="BindingFlags"/> value.</param>
            public BindingSpecification(BindingFlags flags) => _flags = flags;

            /// <summary>
            /// Represents language construct that allows more fluent expressions.
            /// </summary>
            public BindingSpecification Or => this;

            /// <summary>
            /// Represents language construct that allows more fluent expressions.
            /// </summary>
            public BindingSpecification And => this;

            /// <summary>
            /// Returns instance of <see cref="BindingSpecification"/> that represents all (public or nonpublic) static fields.
            /// </summary>
            /// <returns>New instance of <see cref="BindingSpecification"/>.</returns>
            public BindingSpecification AllStatic() => Public().Or.NonPublic().And.Static();

            /// <summary>
            /// Returns instance of <see cref="BindingSpecification"/> that represents all (public or nonpublic) instance fields.
            /// </summary>
            /// <returns>New instance of <see cref="BindingSpecification"/>.</returns>
            public BindingSpecification AllInstance() => Public().Or.NonPublic().And.Instance();

            /// <summary>
            /// ORs current <see cref="BindingSpecification"/> value with <see cref="BindingFlags.Public"/>.
            /// </summary>
            /// <returns>New instance of <see cref="BindingSpecification"/>.</returns>
            public BindingSpecification Public() => With(BindingFlags.Public);

            /// <summary>
            /// ORs current <see cref="BindingSpecification"/> value with <see cref="BindingFlags.NonPublic"/>.
            /// </summary>
            /// <returns>New instance of <see cref="BindingSpecification"/>.</returns>
            public BindingSpecification NonPublic() => With(BindingFlags.NonPublic);

            /// <summary>
            ///     ORs current <see cref="BindingSpecification"/> value with <see cref="BindingFlags.Static"/>.
            /// </summary>
            /// <returns>New instance of <see cref="BindingSpecification"/>.</returns>
            public BindingSpecification Static() => With(BindingFlags.Static);

            /// <summary>
            ///     ORs current <see cref="BindingSpecification"/> value with <see cref="BindingFlags.Instance"/>.
            /// </summary>
            /// <returns>New instance of <see cref="BindingSpecification"/>.</returns>
            public BindingSpecification Instance() => With(BindingFlags.Instance);

            public BindingSpecification OfThatType() => With(~BindingFlags.FlattenHierarchy);

            /// <summary>
            ///     Implicitly casts <see cref="BindingSpecification"/> to <see cref="BindingFlags"/>.
            /// </summary>
            /// <param name="self"><code>this</code> object.</param>
            /// <returns>Instance of <see cref="BindingFlags"/> constructed from <paramref name="self"/>.</returns>
            public static implicit operator BindingFlags(BindingSpecification self) => self._flags;

            private BindingSpecification With(BindingFlags flags) => new BindingSpecification(_flags | flags);
        }
    }
}