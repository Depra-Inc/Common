namespace Depra.Common.Extensions.Text
{
    public static partial class StringExtensions
    {
        public static string WithoutPrefix(this string self, string prefix) =>
            self.StartsWith(prefix) ? self.Substring(prefix.Length) : self;

        public static string WithoutSuffix(this string self, string suffix) =>
            self.EndsWith(suffix) ? self.Remove(self.Length - suffix.Length) : self;

        public static string Without(this string self, string part) =>
            self.Replace(part, "");

        public static string Without(this string self, int charAt) =>
            self.Without(charAt, new char[self.Length - 1]);

        public static string Without(this string self, int charAt, char[] @using)
        {
            if (self.Length == 1)
            {
                return string.Empty;
            }

            for (var i = 0; i < self.Length; i++)
            {
                if (i < charAt)
                {
                    @using[i] = self[i];
                }
                else if (i > charAt)
                {
                    @using[i - 1] = self[i];
                }
            }

            return new string(@using, 0, self.Length - 1);
        }
    }
}