﻿using System;
using System.IO;

namespace Depra.Common.Extensions.IO
{
    public static partial class DirectoryInfoExtensions
    {
        public readonly struct CopyDirectoriesExpression
        {
            private readonly DirectoryInfo _root;
            private readonly Predicate<FileInfo> _file;
            private readonly Predicate<DirectoryInfo> _directory;

            public CopyDirectoriesExpression(DirectoryInfo root, Predicate<FileInfo> file = null,
                Predicate<DirectoryInfo> directory = null)
            {
                _root = root;
                _file = file;
                _directory = directory;
            }

            public CopyDirectoriesExpression Where(Predicate<FileInfo> file) =>
                new CopyDirectoriesExpression(_root, _file == null ? file : _file + file);

            public CopyDirectoriesExpression Where(Predicate<DirectoryInfo> directory) =>
                new CopyDirectoriesExpression(_root, _file, _directory == null ? directory : _directory + directory);

            public void To(string path, string mask = "*.*")
            {
                new CopyFilesExpression(_root, _file).To(path, mask);

                foreach (var x in _root.GetDirectories())
                {
                    var isOk = (_directory?.Invoke(x)).Or(true);
                    if (isOk)
                    {
                        x.Copy()
                            .Where(_file)
                            .Where(_directory)
                            .To($"{path}\\{x.Name}");
                    }
                }
            }
        }
    }
}