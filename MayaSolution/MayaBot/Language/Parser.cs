using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.process;
using edu.stanford.nlp.trees;

namespace MayaBot.Language
{
    public static class Parser
    {
        public static void Initialize()
        {
            languagePackFile = @"D:\Ravi\Lab\Maya_Stuff\englishPCFG.ser.gz";
            grammaticalStructureFactory = new PennTreebankLanguagePack().grammaticalStructureFactory();
            parser = LexicalizedParser.loadModel(languagePackFile);
            tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "");
        }

        public static string GetSubjectOfWhatQuestion(string question, bool includeSubjectModifiers = true)
        {
            var deps = GetDependencyArrayFromSentence(question);

            var subjectDep = deps.Single(dep => GetTypeOfDependency(dep) == "nsubj");
            var retVal = GetValueOfDependency(subjectDep);

            var subjectModifiers = string.Empty;
            if (includeSubjectModifiers)
            {
                foreach (var dep in deps)
                {
                    var modifierType = GetTypeOfDependency(dep);
                    if (modifierType == "amod" || modifierType == "compound")
                    {
                        subjectModifiers = subjectModifiers + GetValueOfDependency(dep) + " ";
                    }
                }
            }

            return $"{subjectModifiers}{retVal}";
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

        #region Private

        private static string languagePackFile;

        private static GrammaticalStructureFactory grammaticalStructureFactory;

        private static LexicalizedParser parser;

        private static TokenizerFactory tokenizerFactory;

        private static TypedDependency[] GetDependencyArrayFromSentence(string sentence)
        {
            var reader = new java.io.StringReader(sentence);
            var words = tokenizerFactory.getTokenizer(reader).tokenize();
            reader.close();
            var tree = parser.apply(words);
            return grammaticalStructureFactory.newGrammaticalStructure(tree).typedDependenciesCCprocessed().toArray()
                .Select(dep => (TypedDependency)dep).ToArray();
        }

        private static string GetTypeOfDependency(TypedDependency dep)
        {
            return dep.reln().getShortName();
        }

        private static string GetValueOfDependency(TypedDependency dep)
        {
            return dep.dep().backingLabel().value();
        }

        #endregion
    }
}
