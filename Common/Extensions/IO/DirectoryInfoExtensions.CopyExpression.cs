using System;
using System.IO;

namespace Depra.Common.Extensions.IO
{
    public static partial class DirectoryInfoExtensions
    {
        public readonly struct CopyExpression
        {
            private readonly DirectoryInfo _root;

            public CopyExpression(DirectoryInfo root) =>
                _root = root;

            public CopyFilesExpression Files =>
                new CopyFilesExpression(_root);

            public CopyDirectoriesExpression Where(Predicate<FileInfo> file) =>
                new CopyDirectoriesExpression(_root, file);

            public CopyDirectoriesExpression Where(Predicate<DirectoryInfo> directory) =>
                new CopyDirectoriesExpression(_root, null, directory);

            public void To(string path, string mask = "*.*") =>
                new CopyDirectoriesExpression(_root).To(path, mask);
        }
    }
}