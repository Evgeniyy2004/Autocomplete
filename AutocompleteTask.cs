// Вставьте сюда финальное содержимое файла AutocompleteTask.cs
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
namespace Autocomplete
{
    internal class AutocompleteTask
    {
        /// <returns>
        /// Возвращает первую фразу словаря, начинающуюся с prefix.
        /// </returns>
        /// <remarks>
        /// Эта функция уже реализована, она заработает, 
        /// как только вы выполните задачу в файле LeftBorderTask
        /// </remarks>
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            return null;
        }

        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            // тут стоит использовать написанный ранее класс LeftBorderTask
            List<string> words = new List<string>() { };
            var c = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            for (int i = c + 1; i < c + count + 1 && i < phrases.Count; i++)
            {
                if (phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) words.Add(phrases[i]);
                else break;
            }
            return words.ToArray();
        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            // тут стоит использовать написанные ранее классы LeftBorderTask и RightBorderTask
            int count = 0;
            var start = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            var end = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);
            for (int i = start + 1; i < end; i++)
            {
                if (phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) count++;
            }
            return count;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            List<string> hehe = new List<string>() { };
            IReadOnlyList<string> phrases = hehe;
            var c = AutocompleteTask.GetTopByPrefix(phrases, "aboba", 8);
            CollectionAssert.IsEmpty(c);
        }

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            List<string> hehe = new List<string>() { "abab", "abob", "daba" };
            IReadOnlyList<string> phrases = hehe;
            var c = AutocompleteTask.GetCountByPrefix(phrases, "");
            Assert.AreEqual(phrases.Count, c);
        }

        // ...
    }
}

