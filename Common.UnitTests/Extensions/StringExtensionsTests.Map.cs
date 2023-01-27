using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions;

public sealed partial class StringExtensionsTests
{
    public class Map
    {
        [Fact]
        public void MapOfCharToString_ShouldReplaceEveryCharacterWithOther() =>
            "1234".Map(_ => '*').Should().Be("****");

        [Fact]
        public void MapOfCharToString_ShouldReplaceEveryCharacterWithString() =>
            "1234".Map(_ => "**").Should().Be("********");
    }
}