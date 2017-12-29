using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaBot.Language
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
            return (double)Parser.LevenshteinDistance(str, otherString) / Math.Max(str.Length, otherString.Length);
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

        #endregion
    }
}
