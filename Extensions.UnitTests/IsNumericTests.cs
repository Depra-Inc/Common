using System;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Common.Extensions.UnitTests
{
    [TestFixture]
    public class IsNumericTests
    {
        [Test]
        public void WhenCheckingIfValueIsNumeric_AndValueIsInteger_ThenValueIsNumeric()
        {
            // Arrange.
            var value = 0;

            // Act.
            var isNumeric = value.IsNumeric();

            // Assert.
            isNumeric.Should().BeTrue();
        }

        [Test]
        public void WhenCheckingIfValueIsNumeric_AndValueIsIntegerAsObject_ThenValueIsNotNumeric()
        {
            // Arrange.
            var value = 0;
            var valueAsObject = (object) value;

            // Act.
            var isNumeric = valueAsObject.IsNumeric();

            // Assert.
            isNumeric.Should().BeFalse();
        }

        [Test]
        public void WhenCheckingIfValueIsNumericAtRuntime_AndValueIsIntegerAsObject_ThenValueIsNumeric()
        {
            // Arrange.
            var value = 0;
            var valueAsObject = (object) value;

            // Act.
            var isNumeric = valueAsObject.IsNumericAtRuntime();

            // Assert.
            isNumeric.Should().BeTrue();
        }

        [Test]
        public void WhenCheckingIfValueIsNullableNumeric_AndValueIsNullableInteger_ThenValueIsNullableNumeric()
        {
            // Arrange.
            int? value = 0;

            // Act.
            var isNullableNumeric = value.IsNullableNumeric();

            // Assert.
            isNullableNumeric.Should().BeTrue();
        }

        [Test]
        public void WhenCheckingIfValueIsNullableNumeric_AndValueIsNullableIntegerAsObject_ThenValueIsNullableNumeric()
        {
            // Arrange.
            int? value = 0;
            var valueAsObject = (object) value;
            
            // Act.
            var isNullableNumeric = valueAsObject.IsNullableNumeric();
            
            // Assert.
            isNullableNumeric.Should().BeTrue();
        }

        [Test]
        public void WhenCheckingIfValueIsNullableNumeric_AndValueIsNull_ThenValueIsNullableNumeric()
        {
            // Arrange.
            int? value = null;
            
            // Act.
            var isNullableNumeric = value.IsNullableNumeric();
            
            // Assert.
            isNullableNumeric.Should().BeTrue();
        }

        [Test]
        public void WhenCheckingIfValueIsNullableNumeric_AndValueIsNullAsObject_ThenValueIsNotNullableNumeric()
        {
            // Arrange.
            int? value = null;
            var valueAsObject = (object) value;
            
            // Act.
            var isNullableNumeric = valueAsObject.IsNullableNumeric();
            
            // Assert.
            isNullableNumeric.Should().BeFalse();
        }

        [Test]
        public void WhenCheckingIfValueIsNullableNumeric_AndValueIsNotNumber_ThenValueIsNotNullableNumeric()
        {
            // Arrange.
            var value = "test";
            
            // Act.
            var isNullableNumeric = value.IsNullableNumeric();
            
            // Assert.
            isNullableNumeric.Should().BeFalse();
        }

        [Test]
        public void WhenCheckingIfValueIsNullableNumeric_AndValueIsNullAndNotNumber_ThenValueIsNotNullableNumeric()
        {
            // Arrange.
            Type? value = null;
            
            // Act.
            var isNullableNumeric = value.IsNullableNumeric();
            
            // Assert.
            isNullableNumeric.Should().BeFalse();
        }
    }
}