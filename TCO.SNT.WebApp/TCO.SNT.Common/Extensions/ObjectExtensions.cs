using System;
using System.Linq;

namespace TCO.SNT.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T x, params T[] set)
        {
            return set.Contains(x);
        }

        public static bool NotIn<T>(this T x, params T[] set)
        {
            return !set.Contains(x);
        }
    }
}
