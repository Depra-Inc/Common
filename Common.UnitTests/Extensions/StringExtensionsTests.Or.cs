using Depra.Common.Extensions.Text;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions;

public sealed partial class StringExtensionsTests
{
    public class Or
    {
        [Fact]
        public void Or_ShouldBeSelf_IfStringIsNotNull() =>
            "Hello".Or("1").Should().Be("Hello");

        [Fact]
        public void Or_ShouldBeDefault_IfStringIsNull() =>
            ((string)null).Or("Hello").Should().Be("Hello");
    }
}