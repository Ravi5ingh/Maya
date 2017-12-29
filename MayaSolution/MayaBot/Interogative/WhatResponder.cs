using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaBot.Knowledge;

namespace MayaBot.Interogative
{
    public class WhatResponder : BaseResponder
    {
        public WhatResponder(Brain brain) : base(brain)
        {
        }

        public override bool CanRespondTo(string message)
        {
            throw new NotImplementedException();
        }

        public override string RespondTo(string message)
        {
            throw new NotImplementedException();
        }
    }
}
