using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaBot.Knowledge;

namespace MayaBot.Response
{
    public abstract class BaseResponder : IResponder
    {
        public abstract bool CanRespondTo(string message);

        public abstract string RespondTo(string message);

        protected BaseResponder(Brain brain)
        {
            this.brain = brain;
        }

        protected Brain brain;
    }
}
