using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaBot.Knowledge;
using MayaBot.Language;
using MayaBot.Utility;

namespace MayaBot.Interogative
{
    public class GreetingResponder : BaseResponder
    {
        public GreetingResponder(Brain brain) : base(brain)
        {
        }

        public override bool CanRespondTo(string message)
        {
            return message.FirstWord().IsIn(recognizedGreetings);
        }

        public override string RespondTo(string message)
        {
            var retVal = string.Empty;
            if (message.WordCount() == 2 && message.SecondWord().IsNot("maya"))
            {
                retVal = $"Hi. Who is {message.SecondWord()}?";
            }
            else
            {
                retVal = "Hello to you too :)";
            }

            return retVal;
        }

        private List<string> recognizedGreetings = new List<string>()
        {
            "hi",
            "hello",
            "hey",
            "yo",
            "howdy",
            "hiya"
        };
    }
}
