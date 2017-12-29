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

        public static TypedDependency[] GetDependencyArrayFromSentence(string sentence)
        {
            var reader = new java.io.StringReader(sentence);
            var words = tokenizerFactory.getTokenizer(reader).tokenize();
            reader.close();
            var tree = parser.apply(words);
            return grammaticalStructureFactory.newGrammaticalStructure(tree).typedDependenciesCCprocessed().toArray()
                .Select(dep => (TypedDependency)dep).ToArray();
        }

        public static string GetTypeOfDependency(TypedDependency dep)
        {
            return dep.reln().getShortName();
        }

        public static string GetValueOfDependency(TypedDependency dep)
        {
            return dep.dep().backingLabel().value();
        }

        public static int GetWordNumberOfDependency(TypedDependency dep)
        {
            return dep.dep().hashCode();
        }

        #region Private

        private static string languagePackFile;

        private static GrammaticalStructureFactory grammaticalStructureFactory;

        private static LexicalizedParser parser;

        private static TokenizerFactory tokenizerFactory;

        #endregion
    }
}
