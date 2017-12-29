using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaBot.Knowledge;
using MayaBot.Utility;

namespace MayaBot.Response.Imperative
{
    public class FarewellResponder : BaseResponder
    {
        public FarewellResponder(Brain brain) : base(brain)
        {
        }

        public override bool CanRespondTo(string message)
        {
            return message.FirstWord().IsIn(farewellSynonyms);
        }

        public override string RespondTo(string message)
        {
            Environment.Exit(0);
            return null;
        }

        private List<string> farewellSynonyms = new List<string>
        {
            "bye",
            "goodbye",
            "bye-bye",
            "adieu",
            "farewell",
            "close",
            "end",
            "stop",
            "terminate",
            "exit"
        };
    }
}
