using Depra.Common.System.Reflection;
using Xunit;

namespace Depra.Common.UnitTests.System.Reflection;

public sealed partial class EmitTests
{
    public class Fields
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(30)]
        public void GetField_ShouldCreateCorrectFunc(int data)
        {
            var field = typeof(WithPublicField).GetField("Data");
            var get = Emit.GetField<WithPublicField>(field);

            Assert.Equal(data, get(new WithPublicField { Data = data }));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(30)]
        public void SetField_ShouldCreateCorrectAction(int data)
        {
            var field = typeof(WithPublicField).GetField("Data");
            var set = Emit.SetField<WithPublicField>(field);
            var instance = new WithPublicField();

            set(instance, data);

            Assert.Equal(data, instance.Data);
        }

        private class WithPublicField
        {
            public int Data;
        }
    }
}