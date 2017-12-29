using System;
using System.Collections.Generic;
using System.IO;
using MayaBot.Utility;

namespace MayaBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Language.Parser.Initialize();
            var deps = Language.Parser.GetDependencyArrayFromSentence("Task scheduler is ts");

            var knowledgeBaseFileInfo = new FileInfo(@"D:\Ravi\Lab\Maya_Stuff\KnowledgeBase.xml");

            var maya = new Maya(knowledgeBaseFileInfo);

            Console.WriteLine(maya.Greeting);
            while (true)
            {
                var messageFromUser = Console.ReadLine();
                Console.WriteLine(maya.RespondTo(messageFromUser));
            }

            Console.WriteLine("Hello World :D");
            Console.ReadLine();
        }
    }
}
