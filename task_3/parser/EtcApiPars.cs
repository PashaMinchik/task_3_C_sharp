using Newtonsoft.Json;
using System;
using System.IO;

namespace task_3.parser
{
    class EtcApiPars
    {
        public string email { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string urlApi { get; set; }
        public string ownerId { get; set; }
        public string picture { get; set; }
        public string apiVersion { get; set; }
    }
    class PathsPars
    {
        public string pathToEtcOfTask { get; set; }
    }
    class ParserEtcApi
    {
        string fileName = @"..\..\..\task_3\etcOfTask\EtcApi.json";

        public string GetParameter(string parameter)
        {
            StreamReader sr = new StreamReader(fileName);
            string Out = sr.ReadToEnd();
            EtcApiPars OtvetName = JsonConvert.DeserializeObject<EtcApiPars>(Out);
            sr.Close();

            string result = null;

            switch (parameter)
            {
                case "email":
                    result = OtvetName.email;
                    break;
                case "password":
                    result = OtvetName.password;
                    break;
                case "token":
                    result = OtvetName.token;
                    break;
                case "urlApi":
                    result = OtvetName.urlApi;
                    break;
                case "ownerId":
                    result = OtvetName.ownerId;
                    break;
                case "picture":
                    result = OtvetName.picture;
                    break;
                case "apiVersion":
                    result = OtvetName.apiVersion;
                    break;
            }

            return result;
        }
    }
}
