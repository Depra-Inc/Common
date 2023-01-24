using System.Collections.Generic;
using Depra.Common.Extensions;
using Depra.Common.Extensions.Collections;
using FluentAssertions;
using Xunit;

namespace Depra.Common.UnitTests.Extensions.Collections
{
    public sealed class DictionaryExtensionsTests
    {
        [Fact]
        public void OneOrDefault_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).OrDefault().Should().Be("");

        [Fact]
        public void OneOr_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).Or("1").Should().Be("");

        [Fact]
        public void OneOrFunc_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).Or(() => "1").Should().Be("");

        [Fact]
        public void OneOrNew_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).OrNew("1").Should().Be("");

        [Fact]
        public void OneOrNewFunc_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).OrNew(() => "1").Should().Be("");

        [Fact]
        public void OneOrThrow_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).OrThrow().Should().Be("");

        [Fact]
        public void OneOrThrowWithMessage_ShouldReturnObject_IfKeyExists() =>
            Dictionary(with: (1, "")).One(1).OrThrow(withMessage: "").Should().Be("");

        [Fact]
        public void OneOrDefault_ShouldReturnDefault_IfKeyDoesNotExist() =>
            Empty<int, string>().One(1).OrDefault().Should().BeNull();

        [Fact]
        public void OneOr_ShouldReturnValue_IfKeyDoesNotExist() =>
            Empty<int, string>().One(1).Or("").Should().Be("");

        [Fact]
        public void OneOrFunc_ShouldReturnValue_IfKeyDoesNotExist() =>
            Empty<int, string>().One(1).Or(() => "").Should().Be("");

        [Fact]
        public void OneOrNew_ShouldWriteNewValue_IfKeyDoesNotExist() =>
            Empty<int, string>()
                .Do(_ => _.One(1).OrNew(""))
                .One(1).OrDefault().Should().Be("");

        [Fact]
        public void OneOrNewFunc_ShouldWriteNewValue_IfKeyDoesNotExist() =>
            Empty<int, string>()
                .Do(_ => _.One(1).OrNew(() => ""))
                .One(1).OrDefault().Should().Be("");

        [Fact]
        public void OneOrThrow_ShouldThrow_IfKeyDoesNotExist() =>
            Assert.Throws<KeyNotFoundException>(() => Empty<int, string>().One(1).OrThrow())
                .Message.Should().Be("Couldn't find value with [ 1 ] key.");

        [Fact]
        public void OneOrThrow_ShouldThrowWithSpecifiedMessage_IfKeyDoesNotExist() =>
            Assert.Throws<KeyNotFoundException>(() => Empty<int, string>().One(1).OrThrow(withMessage: ""))
                .Message.Should().Be("");

        private static IDictionary<TKey, TValue> Empty<TKey, TValue>() where TKey : notnull =>
            new Dictionary<TKey, TValue>();

        private static IDictionary<TKey, TValue> Dictionary<TKey, TValue>((TKey Key, TValue Value) with)
            where TKey : notnull =>
            new Dictionary<TKey, TValue> { { with.Key, with.Value } };
    }
}