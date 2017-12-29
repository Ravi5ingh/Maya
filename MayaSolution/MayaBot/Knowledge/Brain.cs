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
            this.knowledgeBaseFileInfo = knowledgeBaseFile;
            subjects = knowledgeBaseFile != null
                ? Util.DeSerializeAs<List<Subject>>(knowledgeBaseFile)
                : new List<Subject>();
        }

        public bool KnowsAbout(string subjectName)
        {
            return HasSubject(subjectName);
        }

        public void AddToSubject(string subjectName, string infoPoint)
        {
            if (!HasSubject(subjectName))
            {
                subjects.Add(new Subject(subjectName, infoPoint));
            }
            else
            {
                GetSubject(subjectName).InformationPoints.Add(infoPoint);
            }
        }

        public Subject GetSubject(string subjectName)
        {
            return subjects.Single(subject => subjectName.IsIn(subject.SubjectNames));
        }

        public void Save()
        {
            var saveFileInfo = knowledgeBaseFileInfo ?? new FileInfo(".");
            Util.Serialize(subjects, saveFileInfo);
        }

        #endregion

        #region Private

        private List<Subject> subjects;

        private FileInfo knowledgeBaseFileInfo;

        private bool HasSubject(string subjectName)
        {
            return subjects.Any(subject => subjectName.IsIn(subject.SubjectNames));
        }

        #endregion
    }
}
