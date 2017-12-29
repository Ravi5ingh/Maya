using MayaBot.Knowledge;
using MayaBot.Utility;

namespace MayaBot.Response.Imperative
{
    public class ItResponder : BaseResponder
    {
        public ItResponder(Brain brain) : base(brain)
        {
        }

        public override bool CanRespondTo(string message)
        {
            return message.FirstWord().Is("it");
        }

        public override string RespondTo(string message)
        {
            if (Context.CurrentSubject != null)
            {
                message = $"{Context.CurrentSubject.SubjectNames[0]} {message.Substring(3)}";
                return new KnowledgeUpdateResponder(brain).RespondTo(message);
            }

            return $"I don't know what '{message.FirstWord()}' refers to";
        }
    }
}
