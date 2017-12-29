using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaBot.Knowledge
{
    [Serializable]
    public class Subject
    {
        public List<string> SubjectNames { get; set; }

        public List<string> InformationPoints { get; set; }

        public override string ToString()
        {
            return $"{SubjectNames[0]}, {InformationPoints[0]}";
        }
    }
}
