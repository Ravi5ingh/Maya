using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaBot.Utility
{
    public static class StringExtensionMethods
    {
        #region General

        #endregion

        #region Comparison

        public static readonly double stringSimilarityBenchmark = 0.90;

        public static bool IsSimiliarTo(this string str, string otherString)
        {
            return str.GetSimilarityTo(otherString) >= stringSimilarityBenchmark;
        }

        public static double GetSimilarityTo(this string str, string otherString)
        {
            return (double)Util.LevenshteinDistance(str, otherString) / Math.Max(str.Length, otherString.Length);
        }

        public static bool IsNot(this string str, string compareTo)
        {
            return !str.Is(compareTo);
        }

        public static bool Is(this char c, char otherChar)
        {
            return c == otherChar;
        }

        public static bool Is(this string str, string comparedTo)
        {
            return str.ToUpper() == comparedTo.ToUpper();
        }

        public static bool IsIn(this string str, IEnumerable<string> listOfStrings)
        {
            return listOfStrings.Any(str.Is);
        }

        public static bool ContainsWord(this string str, string word)
        {
            return str.Split(' ').Contains(word);
        }

        #endregion

        #region Text manipulation

        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = str.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }

        public static string After(this string str, string fromString)
        {
            return str.Substring(str.IndexOf(fromString) + fromString.Length);
        }

        public static string FirstWord(this string str)
        {
            return str.Word(0);
        }

        public static string SecondWord(this string str)
        {
            return str.Word(1);
        }

        public static string LastWord(this string str)
        {
            return str.Word(str.WordCount() - 1);
        }

        public static char LastChar(this string str)
        {
            return str[str.Length - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="wordIndex">0-based</param>
        /// <returns></returns>
        public static string Word(this string str, int wordIndex)
        {
            var retVal = string.Empty;
            if (str.Contains(' '))
            {
                retVal = str.Split(' ')[wordIndex];
            }
            else if (wordIndex == 0)
            {
                retVal = str;
            }
            else
            {
                return string.Empty;
            }

            return retVal;
        }

        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }

        /// <summary>
        /// Aggregate the contents into a human readable string
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string Aggregate(this IEnumerable<string> arr, string delimiter = ", ")
        {
            var retVal = string.Empty;
            foreach (var element in arr)
            {
                retVal = retVal + delimiter + element;
            }
            return retVal.Length > 2 ? retVal.Substring(delimiter.Length) : retVal;
        }

        #endregion
    }
}
