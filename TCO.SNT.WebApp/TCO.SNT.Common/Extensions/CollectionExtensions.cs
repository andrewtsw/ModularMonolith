using System.Linq;
using System.Collections.Generic;
using System;

namespace TCO.SNT.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static bool NotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return !IsNullOrEmpty(source);
        }

        public static IEnumerable<T> Apply<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var e in source)
            {
                action(e);
                yield return e;
            }
        }
    }
}