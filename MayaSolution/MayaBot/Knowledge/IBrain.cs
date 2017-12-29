using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MayaBot.Knowledge
{
    public interface IBrain
    {
        bool KnowsAbout(string subject);

        void AddToSubject(string subjectName, string infoPoint);

        IList<string> GetInformation(string subjectName);
    }
}
