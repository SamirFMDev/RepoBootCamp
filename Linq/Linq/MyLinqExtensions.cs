using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class MyLinqExtensions
    {
        public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
        {
            return sequence;
        }
        public static int? Median(this IEnumerable<int?> sequence)
        {
            var ordered = sequence.OrderBy(item => item);
            int middlePosition = ordered.Count() / 2;
            return ordered.ElementAt(middlePosition);
        }

        public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Median();
        }

        public static IEnumerable<T> GetOrderedGroups<T>(this IEnumerable<T> secuence)
        {
            var orderedGroup = secuence
                .GroupBy(item => item)
                .OrderBy(item => item.Count())
                .Select(item => item.Key);

            return orderedGroup;
        }

        public static int? Mode<T>(this IEnumerable<T> secuence, Func<T, int?> selector)
        {
            return secuence
                .Select(selector)
                .GetOrderedGroups()
                .LastOrDefault();
        }

        public static int? UnMode<T>(this IEnumerable<T> secuence, Func<T, int?> selector)
        {
            return secuence
                .Select(selector)
                .GetOrderedGroups()
                .FirstOrDefault();
        }
    }
}
