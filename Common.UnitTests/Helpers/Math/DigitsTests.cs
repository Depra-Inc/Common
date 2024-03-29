﻿using Depra.Common.Helpers.Math;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Depra.Common.UnitTests.Helpers.Math;

public class DigitsTests
{
    private readonly ITestOutputHelper _outputHelper;

    public DigitsTests(ITestOutputHelper outputHelper) => _outputHelper = outputHelper;

    [Theory]
    [InlineData(1L, 1)]
    [InlineData(10L, 2)]
    [InlineData(100L, 3)]
    [InlineData(1000L, 4)]
    [InlineData(10000L, 5)]
    [InlineData(100000L, 6)]
    [InlineData(1000000L, 7)]
    [InlineData(10000000L, 8)]
    [InlineData(100000000L, 9)]
    [InlineData(1000000000L, 10)]
    [InlineData(10000000000L, 11)]
    [InlineData(100000000000L, 12)]
    [InlineData(1000000000000L, 13)]
    [InlineData(10000000000000L, 14)]
    [InlineData(100000000000000L, 15)]
    [InlineData(1000000000000000L, 16)]
    [InlineData(10000000000000000L, 17)]
    [InlineData(100000000000000000L, 18)]
    [InlineData(1000000000000000000L, 19)]
    public void Count_ShouldReturnNumberOfDigits_IfLong(long number, int count)
    {
        // Act.
        var actualCount = Digits.Count(number);
        _outputHelper.WriteLine(actualCount.ToString());
            
        // Assert.
        actualCount.Should().Be(count);
    }

    [Theory]
    [InlineData(1.0f, 1)]
    [InlineData(10.0f, 2)]
    [InlineData(100.0f, 3)]
    [InlineData(1000.0f, 4)]
    [InlineData(10000.0f, 5)]
    [InlineData(100000.0f, 6)]
    [InlineData(1000000.0f, 7)]
    [InlineData(10000000.0f, 8)]
    [InlineData(100000000.0f, 9)]
    [InlineData(1000000000.0f, 10)]
    [InlineData(10000000000.0f, 11)]
    [InlineData(100000000000.0f, 12)]
    [InlineData(1000000000000.0f, 13)]
    [InlineData(10000000000000.0f, 14)]
    [InlineData(100000000000000.0f, 15)]
    [InlineData(1000000000000000.0f, 16)]
    [InlineData(10000000000000000.0f, 17)]
    [InlineData(100000000000000000.0f, 18)]
    [InlineData(1000000000000000000.0f, 19)]
    [InlineData(10000000000000000000.0f, 20)]
    [InlineData(100000000000000000000.0f, 21)]
    [InlineData(1000000000000000000000.0f, 22)]
    [InlineData(10000000000000000000000.0f, 23)]
    [InlineData(100000000000000000000000.0f, 24)]
    [InlineData(1000000000000000000000000.0f, 25)]
    [InlineData(10000000000000000000000000.0f, 26)]
    [InlineData(100000000000000000000000000.0f, 27)]
    [InlineData(1000000000000000000000000000.0f, 28)]
    [InlineData(10000000000000000000000000000.0f, 29)]
    [InlineData(100000000000000000000000000000.0f, 30)]
    [InlineData(1000000000000000000000000000000.0f, 31)]
    [InlineData(10000000000000000000000000000000.0f, 32)]
    [InlineData(100000000000000000000000000000000.0f, 33)]
    [InlineData(1000000000000000000000000000000000.0f, 34)]
    [InlineData(10000000000000000000000000000000000.0f, 35)]
    [InlineData(100000000000000000000000000000000000.0f, 36)]
    [InlineData(1000000000000000000000000000000000000.0f, 37)]
    [InlineData(10000000000000000000000000000000000000.0f, 38)]
    [InlineData(100000000000000000000000000000000000000.0f, 39)]
    public void Count_ShouldReturnNumberOfDigits_IfFloat(float number, int count)
    {
        // Act.
        var actualCount = Digits.Count(number);
        _outputHelper.WriteLine(actualCount.ToString());
            
        // Assert.
        actualCount.Should().Be(count);
    }
}