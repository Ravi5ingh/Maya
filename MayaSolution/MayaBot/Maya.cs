using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaBot.Interogative;
using MayaBot.Knowledge;

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
                new WhatResponder(brain)
            };
        }

        public string RespondTo(string message)
        {
            foreach (var responder in responders)
            {
                if (responder.CanRespondTo(message))
                {
                    return responder.RespondTo(message);
                }
            }

            return "I'm sorry I dont't understand. I can only deal with simple requests";
        }

        private Brain brain;

        private List<IResponder> responders;
    }
}
