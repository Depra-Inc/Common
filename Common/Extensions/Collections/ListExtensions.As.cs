using System;
using System.Collections.Generic;
using System.Linq;

namespace Depra.Common.Extensions.Collections
{
    public static partial class ListExtensions
    {
        public static string AsString<T>(this IList<T> self) =>
            self.AsString(x => x?.ToString() ?? "null");

        public static string AsString<T>(this IList<T> self, Func<T, object> asString) =>
            self.AsString(x => x != null ? asString(x).ToString() : "null");

        public static string AsString<T>(this IList<T> self, Func<T, string> asString) => self.IsNullOrEmpty()
            ? "[]"
            : $"[ {self.Select(x => $"{asString(x) ?? "null"}").Separated(with: ", ")} ]";
    }
}