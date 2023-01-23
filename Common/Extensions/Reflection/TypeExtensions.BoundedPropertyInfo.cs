using System.Reflection;

namespace Depra.Common.Extensions.Reflection
{
    public static partial class TypeExtensions
    {
        public readonly struct BoundedPropertyInfo
        {
            private readonly object _this;
            private readonly PropertyInfo _property;

            public BoundedPropertyInfo(object @this, PropertyInfo property)
            {
                _this = @this;
                _property = property;
            }

            public PropertyInfo Info =>
                _property;

            public object Value =>
                _property.GetValue(_this);
            
            public T As<T>() => (T)
                _property.GetValue(_this);

            public void Set(object value) =>
                _property.SetValue(_this, value);
        }
    }
}