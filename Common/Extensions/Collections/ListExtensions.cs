using System.Collections.Generic;

namespace Depra.Common.Extensions.Collections
{
    /// <summary>
    /// Represents extension-methods for <see cref="List{T}"/>.
    /// </summary>
    public static partial class ListExtensions
    {
        /// <summary>
        /// Returns next item in the list.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="current"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Next<T>(this IList<T> collection, T current)
        {
            var index = collection.IndexOf(current);
            if (index < collection.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            return collection[index];
        }

        /// <summary>
        /// Returns previous item in the list.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="current"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Previous<T>(this IList<T> collection, T current)
        {
            var index = collection.IndexOf(current);
            if (index > 0)
            {
                index--;
            }
            else
            {
                index = collection.Count - 1;
            }

            return collection[index];
        }

        /// <summary>
        /// Removes the last <paramref name="n"/> item(s) in the list.
        /// </summary>
        public static void RemoveLast<T>(this IList<T> source, int n = 1)
        {
            for (var i = 0; i < n; i++)
            {
                source.RemoveAt(source.Count - 1);
            }
        }

        /// <summary>
        /// Returns a list of numbers from zero to length.
        /// </summary>
        /// <param name="lenght">Maximum number</param>
        /// <returns>List of integers</returns>
        public static List<int> GenerateIndexList(int lenght)
        {
            var indexList = new List<int>();

            var i = 0;
            while (i < lenght)
            {
                indexList.Add(i);
                i++;
            }

            return indexList;
        }
    }
}