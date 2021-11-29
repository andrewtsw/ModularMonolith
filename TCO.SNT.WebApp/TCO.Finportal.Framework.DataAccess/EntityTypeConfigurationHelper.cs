using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace TCO.Finportal.Framework.DataAccess
{
    public static class EntityTypeConfigurationHelper
    {
        public static ValueConverter<T[], string> BuildValueConverter<T>()
        {
            return new ValueConverter<T[], string>(
                v => ArrayToString(v),
                v => ArrayFromString<T>(v));
        }

        public static ValueComparer<T[]> BuildValueComparer<T>()
        {
            return new ValueComparer<T[]>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());
        }

        private static string ArrayToString<T>(T[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            return string.Join(',', values);
        }

        private static T[] ArrayFromString<T>(string str)
        {
            if (string.IsNullOrEmpty(str))
                return Array.Empty<T>();

            return str
                .Split(',')
                .Select(x => (T)Enum.Parse(typeof(T), x))
                .ToArray();
        }
    }
}
