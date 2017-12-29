using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using com.sun.org.apache.xml.@internal.serialize;

namespace MayaBot.Utility
{
    public static class Util
    {
        public static void Serialize<T>(T obj, FileInfo fileInfo)
        {
            var serializerObject = new XmlSerializer(typeof(T));
            var stream = new StreamWriter(fileInfo.FullName);
            serializerObject.Serialize(stream, obj);
            stream.Close();
        }

        public static T DeSerializeAs<T>(FileInfo fileInfo)
        {
            var serializerObject = new XmlSerializer(typeof(T));
            var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var retVal = (T)serializerObject.Deserialize(stream);
            stream.Close();
            return retVal;
        }
        
        /// <summary>
        /// Compute the distance between two strings.
        /// <remarks>
        /// i just ripped this off of the net. need to find most optimal algorithm from list here : (https://en.wikipedia.org/wiki/Category:String_similarity_measures)
        /// </remarks>
        /// </summary>
        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }
            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}
