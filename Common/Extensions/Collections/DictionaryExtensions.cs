using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Depra.Common.Extensions.Collections
{
    /// <summary>
    /// Represents extension-methods for <see cref="Dictionary{TKey,TValue}"/>.
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
        
        /// <summary>
        /// Starts fluent expression of retrieving value of dictionary by specified <paramref name="withKey"/>.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="withKey">Key of value.</param>
        /// <typeparam name="TKey">Type of keys in dictionary.</typeparam>
        /// <typeparam name="TValue">Type of values in dictionary.</typeparam>
        /// <returns><see cref="Value{TKey,TValue}"/> object that can be used to retrieve value by specified key in various ways.</returns>
        public static Value<TKey, TValue> One<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey withKey) =>
            new Value<TKey, TValue>(self, withKey);

        /// <summary>
        /// Represents value entry of some <see cref="IDictionary{TKey,TValue}"/> instance.
        /// </summary>
        /// <typeparam name="TKey">Type of keys in dictionary.</typeparam>
        /// <typeparam name="TValue">Type of values in dictionary.</typeparam>
        public readonly struct Value<TKey, TValue>
        {
            private readonly TKey _key;
            private readonly IDictionary<TKey, TValue> _dictionary;

            internal Value(IDictionary<TKey, TValue> dictionary, TKey key)
            {
                _dictionary = dictionary;
                _key = key;
            }

            /// <summary>
            /// Returns value retrieved by specified key or default <typeparamref name="TValue"/> if one doesn't exist.
            /// </summary>
            /// <returns>Either value by specified key or default of <typeparamref name="TValue"/>.</returns>
            public TValue OrDefault() => Or(default(TValue));

            /// <summary>
            /// Returns value retrieved by specified key or <paramref name="default"/>.
            /// </summary>
            /// <param name="default">Value that will be returned instead of value by specified key.</param>
            /// <returns>Either value by specified key or <paramref name="default"/>.</returns>
            public TValue Or(TValue @default) => _dictionary.TryGetValue(_key, out var value) ? value : @default;

            /// <summary>
            /// Returns value retrieved by specified key or value of <paramref name="default"/> function.
            /// </summary>
            /// <param name="default">Function that returns value that will be returned instead of value by specified key.</param>
            /// <returns>Either value by specified key or value of <paramref name="default"/> function.</returns>
            public TValue Or(Func<TValue> @default) =>
                _dictionary.TryGetValue(_key, out var value) ? value : @default();

            /// <summary>
            /// Returns value retrieved by specified key or <paramref name="default"/> writing it to the dictionary.
            /// </summary>
            /// <param name="default">Value that will be returned instead of value by specified key.</param>
            /// <returns>Either value by specified key or <paramref name="default"/>.</returns>
            public TValue OrNew(TValue @default) =>
                _dictionary.TryGetValue(_key, out var value) ? value : _dictionary[_key] = @default;

            /// <summary>
            /// Returns value retrieved by specified key or value of <paramref name="default"/> function writing it to the dictionary.
            /// </summary>
            /// <param name="default">Function that returns value that will be returned instead of value by specified key.</param>
            /// <returns>Either value by specified key or value of <paramref name="default"/> function.</returns>
            public TValue OrNew(Func<TValue> @default) => _dictionary.TryGetValue(_key, out var value)
                ? value : _dictionary[_key] = @default();

            /// <summary>
            /// Returns value retrieved by specified key or value of <paramref name="default"/> function writing it to the dictionary.
            /// </summary>
            /// <param name="default">Function that returns value that will be returned instead of value by specified key.</param>
            /// <returns>Either value by specified key or value of <paramref name="default"/> function.</returns>
            public TValue OrNew(Func<TKey, TValue> @default) => _dictionary.TryGetValue(_key, out var value)
                ? value : _dictionary[_key] = @default(_key);

            /// <summary>
            /// Returns value retrieved by specified key or throws verbose exception if one doesn't exist.
            /// </summary>
            /// <returns>Value by specified key.</returns>
            /// <remarks>This call is equivalent to <code>dictionary[key]</code>, but it'll throw more verbose exception, but it'll throw more verbose exception.</remarks>
            public TValue OrThrow() => OrThrow($"Couldn't find value with [ {_key} ] key.");

            /// <summary>
            /// Returns value retrieved by specified key or throws verbose exception if one doesn't exist.
            /// </summary>
            /// <param name="withMessage">Message of exception that will be thrown if there is no value with specified key.</param>
            /// <returns>Value by specified key.</returns>
            /// <remarks>This call is equivalent to <code>dictionary[key]</code>, but it'll throw more verbose exception.</remarks>
            public TValue OrThrow(string withMessage) => _dictionary.TryGetValue(_key, out var value)
                ? value : throw new KeyNotFoundException(withMessage);
        }
    }
}