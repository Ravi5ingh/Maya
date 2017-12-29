using System.Diagnostics;
using MayaBot.Knowledge;
using MayaBot.Language;
using MayaBot.Utility;

namespace MayaBot.Interogative
{
    public class WhatResponder : BaseResponder
    {
        public WhatResponder(Brain brain) : base(brain)
        {
        }

        public override bool CanRespondTo(string message)
        {
            return message.FirstWord().Is("What");
        }

        public override string RespondTo(string message)
        {
            var subject = Parser.GetSubjectOfWhatQuestion(message);
            string retVal;
            if (brain.KnowsAbout(subject))
            {
                var info = brain.GetInformation(subject);
                retVal = $"This is what I know about {subject}:\n{info.Aggregate("\n")}";
            }
            else
            {
                Process.Start("chrome", @"https://www.google.com/search?q=" + subject.Replace(" ", "%20"));
                retVal = $"I don't know anything about {subject}. I've searched it in the browser for you";
            }

            return retVal;
        }
    }
}
