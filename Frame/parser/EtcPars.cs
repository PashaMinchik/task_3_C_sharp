using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SelenoidModalWindows.parser
{
    class EtcApiPars
    {
        public List<string> chromeNames { get; set; }
        public List<string> foxNames { get; set; }

    }
    class ParserEtcApi
    {
        public List<string> GetListParameters(string parameter)
        {
            string fileName = @"Frame\etcOfTask\BrowserNames.json";
            StreamReader sr = new StreamReader(fileName);
            string Out = sr.ReadToEnd();
            EtcApiPars OtvetName = JsonConvert.DeserializeObject<EtcApiPars>(Out);
            sr.Close();

            List<string> result = new List<string>();

            switch (parameter)
            {
                case "chromeNames":
                    result = OtvetName.chromeNames;
                    break;
                case "foxNames":
                    result = OtvetName.foxNames;
                    break;
            }
            return result;

        }
    }
}
