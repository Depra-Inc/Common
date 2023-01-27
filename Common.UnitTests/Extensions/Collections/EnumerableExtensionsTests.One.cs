using System;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections;

public sealed partial class EnumerableExtensionsTests
{
    public class One
    {
        [Fact]
        public void One_ShouldReturnItemThatMatchesPredicate_IfIemExists()
        {
            // Arrange.
            var items = new[] { 1, 2, 3 };

            // Act.
            var item = items.One(x => x == 1);

            // Assert.
            item.Should().Be(1);
        }

        [Fact]
        public void One_ShouldReturnDefault_IfItemDoesNotExist()
        {
            // Arrange,
            var items = new[] { "1", "2", "3" };

            // Act;
            var item = items.One(x => x == "0");

            // Assert.
            item.Should().BeNull();
        }

        [Fact]
        public void One_ShouldThrowInvalidOperationExceptionWithSpecifiedMessage_IfItemDoesNotExist()
        {
            // Arrange.
            const string message = "Message";
            var items = new[] { "1", "2", "3" };

            // Act.
            var exception = Assert.Throws<InvalidOperationException>(() =>
                items.One(x => x == "0", message));

            // Assert.
            exception.Message.Should().Be(message);
        }
    }
}