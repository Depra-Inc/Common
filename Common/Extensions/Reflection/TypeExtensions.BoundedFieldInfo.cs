using System.Reflection;

namespace Depra.Common.Extensions.Reflection
{
    public static partial class TypeExtensions
    {
        public readonly struct BoundedFieldInfo
        {
            private readonly object _this;
            private readonly FieldInfo _field;

            public BoundedFieldInfo(object @this, FieldInfo field)
            {
                _this = @this;
                _field = field;
            }

            public FieldInfo Info => _field;

            public object Value =>
                _field.GetValue(_this);

            public T As<T>() => (T)
                _field.GetValue(_this);

            public void Set(object value) =>
                _field.SetValue(_this, value);
        }
    }
}