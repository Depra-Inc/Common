﻿using System;
using System.IO;
using System.Threading.Tasks;
using Depra.Common.System;

namespace Depra.Common.Extensions.IO
{
    /// <summary>
    /// Represents extension-methods for <see cref="Stream"/>.
    /// </summary>
    public static class StreamExtensions
    {
        public static async Task<string> Text(this Stream self)
        {
            using var reader = new StreamReader(self);
            return await reader.ReadToEndAsync();
        }

        public static Task<byte[]> Bytes(this Stream self) => self.Bytes(self.Length, Progress.Fake<int>());
        
        public static async Task<byte[]> Bytes(this Stream self, long length, IProgress<int> progress)
        {
            var bytes = new byte[length];
            var total = 0;

            while (total != length)
            {
                var read = await self.ReadAsync(bytes, total, (int) (length - total));
                if (read == 0)
                {
                    throw new Exception($"Expected to read at least [ {length} ] number of bytes, but got only [ {total} ].");
                }

                total += read;
                progress.Report((int) ((double) total / length * 100));
            }
            
            return bytes;
        }
    }
}