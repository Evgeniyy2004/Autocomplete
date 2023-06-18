// Вставьте сюда финальное содержимое файла RightBorderTask.cs
// Вставьте сюда финальное содержимое файла RightBorderTask.cs
using System;
using System.Collections.Generic;
using System.Linq;
namespace Autocomplete
{
    public class RightBorderTask
    {
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (prefix.Length == 0) return phrases.Count;
            while (right - left > 1)
            {
                var middle = (right + left) / 2;
                if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) >= 0) left = middle;
                else if (phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = middle;
                else right = middle;
            }
            return right;
        }
    }
}