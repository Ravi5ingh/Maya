using System;
using System.Linq;
using MayaBot.Knowledge;
using MayaBot.Language;
using MayaBot.Utility;

namespace MayaBot.Response.Imperative
{
    public class KnowledgeUpdateResponder : BaseResponder
    {
        public KnowledgeUpdateResponder(Brain brain) : base(brain)
        {
        }

        public override bool CanRespondTo(string message)
        {
            return message.StartsWith("remember that", StringComparison.OrdinalIgnoreCase);
        }

        public override string RespondTo(string message)
        {
            message = message.Replace("remember that ", "", StringComparison.OrdinalIgnoreCase);

            var deps = Parser.GetDependencyArrayFromSentence(message);

            //Get the first subject of the sentence
            var subject = Parser.GetValueOfDependency(deps.Where(dep => Parser.GetTypeOfDependency(dep).Is("nsubj"))
                .OrderBy(Parser.GetWordNumberOfDependency).First());

            brain.AddToSubject(subject, message);

            return $"Ok, this is what I've understood about the {subject}\n{message}.\n\n I've updated the knowledge base";
        }
    }
}
