using System;
using System.IO;

namespace Depra.Common.Extensions.IO
{
    public static partial class DirectoryInfoExtensions
    {
        public readonly struct ClearExpression
        {
            private readonly DirectoryInfo _root;
            private readonly Predicate<FileInfo> _file;
            private readonly Predicate<DirectoryInfo> _directory;

            public ClearExpression(DirectoryInfo root, Predicate<FileInfo> file = null, Predicate<DirectoryInfo> directory = null)
            {
                _root = root;
                _file = file;
                _directory = directory;
            }

            public void Files()
            {
                if (_root.Exists == false)
                {
                    return;
                }

                foreach (var x in _root.GetFiles())
                {
                    var isOk = (_file?.Invoke(x)).Or(true);
                    if (isOk)
                    {
                        x.Delete();
                    }
                }
            }

            public void Directories()
            {
                if (_root.Exists == false)
                {
                    return;
                }

                foreach (var x in _root.GetDirectories())
                {
                    var isOk = (_directory?.Invoke(x)).Or(true);
                    if (isOk == false)
                    {
                        continue;
                    }
                    
                    x.Clear().Directories();
                    x.Delete();
                }
            }

            public void All()
            {
                Files();
                Directories();
            }
        }
    }
}