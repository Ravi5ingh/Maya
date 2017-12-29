using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayaBot.Utility;

namespace MayaBot.Knowledge
{
    #region Interface

    public class Brain : IBrain
    {
        public Brain(FileInfo knowledgeBaseFile = null)
        {
            subjects = knowledgeBaseFile != null
                ? Util.DeSerializeAs<List<Subject>>(knowledgeBaseFile)
                : new List<Subject>();
        }

        public bool KnowsAbout(string subjectName)
        {
            return subjects.Any(subject => subjectName.IsIn(subject.SubjectNames));
        }

        public void AddToSubject(string subjectName, string infoPoint)
        {
            GetSubject(subjectName).InformationPoints.Add(infoPoint);
        }

        public IList<string> GetInformation(string subjectName)
        {
            return GetSubject(subjectName).InformationPoints;
        }

        public void Save()
        {
            var saveFileInfo = knowledgeBaseFileInfo ?? new FileInfo("");
            Util.Serialize(subjects, saveFileInfo);
        }

        #endregion

        #region Private

        private IList<Subject> subjects;

        private FileInfo knowledgeBaseFileInfo;

        private Subject GetSubject(string subjectName)
        {
            return subjects.Single(subject => subjectName.IsIn(subject.SubjectNames));
        }

        #endregion
    }
}
