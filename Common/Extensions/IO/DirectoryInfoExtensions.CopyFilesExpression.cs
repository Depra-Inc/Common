using System;
using System.IO;
using Depra.Common.Extensions.Text;

namespace Depra.Common.Extensions.IO
{
    public static partial class DirectoryInfoExtensions
    {
        public readonly struct CopyFilesExpression
        {
            private readonly DirectoryInfo _root;
            private readonly Predicate<FileInfo> _file;

            public CopyFilesExpression(DirectoryInfo root, Predicate<FileInfo> file = null)
            {
                _root = root;
                _file = file;
            }

            public CopyFilesExpression Where(Predicate<FileInfo> file) =>
                new CopyFilesExpression(_root, _file == null ? file : _file + file);

            public void To(string path, string mask = "*.*")
            {
                if (Directory.Exists(path) == false)
                {
                    path.AsDirectory().Create();
                }

                foreach (var fileInfo in _root.GetFiles(mask))
                {
                    var isOk = (_file?.Invoke(fileInfo)).Or(true);
                    if (isOk)
                    {
                        fileInfo.CopyTo($"{path}\\{fileInfo.Name}", overwrite: true);
                    }
                }
            }
        }
    }
}