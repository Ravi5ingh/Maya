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
            return message.StartsWith("update", StringComparison.OrdinalIgnoreCase);
        }

        public override string RespondTo(string message)
        {
            message = message.Replace("update ", "", StringComparison.OrdinalIgnoreCase);

            var deps = Parser.GetDependencyArrayFromSentence(message);

            //Get the first subject of the sentence
            var subject = Parser.GetValueOfDependency(deps.Where(dep => Parser.GetTypeOfDependency(dep).Is("nsubj"))
                .OrderBy(Parser.GetWordNumberOfDependency).First());

            brain.AddToSubject(subject, message);
            Context.CurrentSubject = brain.GetSubject(subject);

            return $"Update to knowledge base about ({subject}):\n{message}";
        }
    }
}
