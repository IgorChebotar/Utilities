using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace SimpleMan.Utilities
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Returns random element from collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Random<T>(this IEnumerable<T> source)
        {
            int randomIndex = UnityEngine.Random.Range(0, source.Count());
            return source.ElementAt(randomIndex);
        }

        /// <summary>
        /// Apply [action] to each element in collecion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);
        }

        /// <summary>
        /// Returns collection without target element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T element)
        {
            foreach(T item in source)
            {
                if (item.Equals(element))
                    continue;

                yield return item;
            }
        }

        /// <summary>
        /// Returns collection without null elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Validate<T>(this IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                if (item != null)
                    yield return item;
            }
        }

        /// <summary>
        /// Throws an exeption when at lest one elemet is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> AssertNoNullElements<T>(this IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                if (item.NotExist())
                {
                    throw new NullReferenceException(
                        "Collection must not contain null elements");
                }     
            }

            return source;
        }

        /// <summary>
        /// Get index of pair
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetElementIndexByKey<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey element)
        {
            if(!source.ContainsKey(element))
            {
                throw new ArgumentException(
                    $"Dictionary not contains key '{element}'. " +
                    $"Use 'Contains' method before index cheking");
            }
            
            int index = 0;
            foreach (var pair in source)
            {
                if(pair.Key.Equals(element))
                    return index;

                index++;
            }

            return -1;
        }

        /// <summary>
        /// Add element if it is not presented in collecion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="item"></param>
        public static void AddUnique<T>(this IList<T> target, T item)
        {
            if (target.Contains(item))
                return;
            else
                target.Add(item);
        }

        /// <summary>
        /// Add items that are not presented in collection 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="items"></param>
        public static void AddUnique<T>(this IList<T> target, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (!target.Contains(item))
                    target.Add(item);
            }
        }

        /// <summary>
        /// Add element if it is not presented in collecion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="item"></param>
        public static void AddUnique<T>(this Queue<T> target, T item)
        {
            if (target.Contains(item))
                return;
            else
                target.Enqueue(item);
        }

        /// <summary>
        /// Add element if it is not presented in collecion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="item"></param>
        public static void AddUnique<T>(this Stack<T> target, T item)
        {
            if (target.Contains(item))
                return;
            else
                target.Push(item);
        }

        /// <summary>
        /// Add item only if key is not exist in this dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddUnique<TKey, TValue>(this IDictionary<TKey, TValue> target, TKey key, TValue value)
        {
            if (target.ContainsKey(key))
                return;
            else
                target.Add(key, value);
        }
    }
}