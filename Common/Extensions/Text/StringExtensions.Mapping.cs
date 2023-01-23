using System;
using System.Text;

namespace Depra.Common.Extensions.Text
{
    public static partial class StringExtensions
    {
        public static string Map(this string self, Func<char, char> map)
        {
            var text = new StringBuilder();

            foreach (var ch in self)
            {
                text.Append(map(ch));
            }
            
            return text.ToString();
        }
        
        public static string Map(this string self, Func<char, string> map)
        {
            var text = new StringBuilder();

            foreach (var ch in self)
            {
                text.Append(map(ch));
            }
            
            return text.ToString();
        }
    }
}