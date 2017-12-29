using System;
using System.IO;

namespace MayaBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
