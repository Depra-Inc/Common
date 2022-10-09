using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Depra.Common.Collections.Extensions
{
    /// <summary>
    /// <see cref="Dictionary{TKey,TValue}"/> extensions.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Returns value for key if exists or default{<typeparamref name="TValue"/>}.
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary.GetValueOrDefault(key, default);

        /// <summary>
        /// Returns value for key if exists or <paramref name="defaultValue"/>.
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
            TValue defaultValue) => dictionary.TryGetValue(key, out var value) ? value : defaultValue;

        /// <summary>
        /// Returns the <paramref name="dictionary"/> as read-only.
        /// </summary>
        public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) =>
            new ReadOnlyDictionary<TKey, TValue>(dictionary);

        public static void AddManyKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys,
            TValue value)
        {
            foreach (var key in keys)
            {
                if (dictionary.ContainsKey(key) == false)
                {
                    dictionary.Add(key, value);
                }
            }
        }

        public static Dictionary<string, T> RemoveNullValues<T>(this Dictionary<string, T> sounds)
        {
            var result = new Dictionary<string, T>();
            foreach (var keyValuePair in sounds)
            {
                var key = keyValuePair.Key;
                var value = keyValuePair.Value;
                
                if (value == null)
                {
                    continue;
                }

                if (result.ContainsKey(key) == false)
                {
                    result.Add(key, value);
                }
            }

            return result;
        }
    }
}