using System.Xml;

namespace task_3.parser
{
    public class EtcParsing
    {
        private const string Filename = "C:\\Users\\p.minchik\\source\\repos\\task_3\\task_3\\etc\\etc.xml";

        public static string Parser(string chooseNode)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Filename);
            string xpath = "etc";
            var nodes = doc.SelectNodes(xpath);
            string text = null;
            foreach (XmlNode node in nodes)
            {
                text = node.SelectSingleNode(chooseNode).InnerText;
                return text;
            }return text;
        }
    }
}
