using System.IO;
using Depra.Common.Extensions.Text;

namespace Depra.Common.Extensions.IO
{
    /// <summary>
    /// Represents extension-methods for <see cref="DirectoryInfo"/>.
    /// </summary>
    public static partial class DirectoryInfoExtensions
    {
        public static DirectoryInfo Combined(this DirectoryInfo self, string with) =>
            Path.Combine(self.FullName, with).AsDirectory();

        public static CopyExpression Copy(this DirectoryInfo self) =>
            new CopyExpression(self);

        public static ClearExpression Clear(this DirectoryInfo self) =>
            new ClearExpression(self);
    }
}