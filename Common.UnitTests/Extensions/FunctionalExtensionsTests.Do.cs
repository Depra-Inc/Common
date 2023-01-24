using System;
using Depra.Common.Extensions;
using NSubstitute;
using Xunit;

namespace Depra.Common.UnitTests.Extensions
{
    public sealed partial class FunctionalExtensionsTests
    {
        public class Do
        {
            [Fact]
            public void Do_ShouldApplyAction()
            {
                var action = Substitute.For<Action<string>>();

                "".Do(action);

                action.Received(1).Invoke("");
            }
            
            [Fact]
            public void Do_ShouldPropagate_IfActionIsNull() => "".Do(null);
        }
    }
}