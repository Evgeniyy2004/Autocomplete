using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            //IReadOnlyList похож на List, но у него нет методов модификации списка.
            //Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!
            if (right - left == 1)
            {
                return left;
            }
            var middle = (left + right) / 2;
            if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) <= 0) return GetLeftBorderIndex(phrases, prefix, left, middle);
            else return GetLeftBorderIndex(phrases, prefix, middle, right);
        }
    }
}