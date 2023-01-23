using System.IO;

namespace Depra.Common.Extensions.Text
{
    public static partial class StringExtensions
    {
        public static int AsInt(this string self) =>
            self.As(int.Parse);
        public static int AsInt(this string self, int or) =>
            int.TryParse(self, out var result) ? result : or;
        
        public static long AsLong(this string self) =>
            self.As(long.Parse);
        public static long AsLong(this string self, long or) =>
            long.TryParse(self, out var result) ? result : or;
        
        public static float AsFloat(this string self) =>
            self.As(float.Parse);
        public static float AsFloat(this string self, float or) =>
            float.TryParse(self, out var result) ? result : or;
            
        public static double AsDouble(this string self) =>
            self.As(double.Parse);
        public static double AsDouble(this string self, float or) =>
            double.TryParse(self, out var result) ? result : or;
        
        public static DirectoryInfo AsDirectory(this string self) => new DirectoryInfo(self);
    }
}