using System.Collections.Generic;
using System.IO;
using MayaBot.Knowledge;
using MayaBot.Response;
using MayaBot.Response.Imperative;
using MayaBot.Response.Interogative;

namespace MayaBot
{
    public class Maya : IMaya
    {
        public string Greeting => "Hi, I'm Maya";

        public Maya(FileInfo knowledgeBaseFileInfo = null)
        {
            Language.Parser.Initialize();
            brain = new Brain(knowledgeBaseFileInfo);
            responders = new List<IResponder>()
            {
                new GreetingResponder(brain),
                new WhatResponder(brain),
                new KnowledgeUpdateResponder(brain),
                new FarewellResponder(brain)
            };
        }

        public string RespondTo(string message)
        {
            foreach (var responder in responders)
            {
                if (responder.CanRespondTo(message))
                {
                    var retVal = responder.RespondTo(message);
                    brain.Save();
                    return retVal;
                }
            }

            return "I'm sorry I dont't understand. I can only deal with simple requests";
        }

        private Brain brain;

        private List<IResponder> responders;
    }
}
