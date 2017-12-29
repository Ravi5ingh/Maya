using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaBot.Knowledge
{
    #region Interface

    public class Brain : IBrain
    {
        public Brain(FileInfo knowledgeBase = null)
        {
            if (knowledgeBase != null)
            {
                //upload during runtime
            }
            else
            {
                subjects = new List<Subject>();
            }
        }

        public bool KnowsAbout(string subjectName)
        {
            return subjects.Any(subject => subject.SubjectNames.Contains(subjectName));
        }

        public void AddToSubject(string subjectName, string infoPoint)
        {
            GetSubject(subjectName).InformationPoints.Add(infoPoint);
        }

        public IList<string> GetInformation(string subjectName)
        {
            return GetSubject(subjectName).InformationPoints;
        }

        #endregion

        #region Private

        private IList<Subject> subjects;

        private Subject GetSubject(string subjectName)
        {
            return subjects.Single(subject => subject.SubjectNames.Contains(subjectName));
        }

        #endregion
    }
}
