using System.Xml;
using System.Xml.Linq;

namespace task_3.parser
{
    public class EtcParsing
    {
        //private string Filename = @"C:\Users\p.minchik\source\repos\task_3\task_3\etc.xml";
        static XDocument doc = XDocument.Load(@"C:\Users\p.minchik\source\repos\task_3\task_3\etc.xml");
        public static string Parser(string nameNode)
        {
            string text = null;
            //string Filename = @"C:\Users\p.minchik\source\repos\task_3\task_3\etc.xml";
            
            //XDocument doc = XDocument.Load(Filename);
            var authors = doc.Descendants(nameNode);
            foreach (var author in authors)
            {
                text = author.Value;
            }
            return text;
        }
    }
}
