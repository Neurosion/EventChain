using System;

namespace EventChain.Core.Extensions
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string source, bool isCaseSensitive = false)
        {
            return (T)Enum.Parse(typeof(T), source, !isCaseSensitive);
        }
    }
}