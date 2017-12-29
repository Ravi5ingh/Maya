using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaBot
{
    public interface IMaya
    {
        /// <summary>
        /// Say something to <see cref="Maya"/> and get a response
        /// </summary>
        /// <param name="text">The message</param>
        /// <returns>The response from <see cref="Maya"/></returns>
        string RespondTo(string text);
    }
}
