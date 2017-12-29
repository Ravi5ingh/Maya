using System.Diagnostics;
using System.Linq;
using MayaBot.Knowledge;
using MayaBot.Language;
using MayaBot.Utility;

namespace MayaBot.Response.Interogative
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
            var subject = GetSubjectOfQuestion(message);
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

        private static string GetSubjectOfQuestion(string question, bool includeSubjectModifiers = true)
        {
            var deps = Parser.GetDependencyArrayFromSentence(question);

            var subjectDep = deps.Single(dep => Parser.GetTypeOfDependency(dep) == "nsubj");
            var retVal = Parser.GetValueOfDependency(subjectDep);

            var subjectModifiers = string.Empty;
            if (includeSubjectModifiers)
            {
                foreach (var dep in deps)
                {
                    var modifierType = Parser.GetTypeOfDependency(dep);
                    if (modifierType == "amod" || modifierType == "compound")
                    {
                        subjectModifiers = subjectModifiers + Parser.GetValueOfDependency(dep) + " ";
                    }
                }
            }

            return $"{subjectModifiers}{retVal}";
        }
    }
}
