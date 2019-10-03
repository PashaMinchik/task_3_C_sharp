using System;
using System.Linq;
using task_3.parser;

namespace task_3.vkapi
{
    public class VkApiUtils
    {
        //private static EtcParsing parser = new EtcParsing();
        private string ownerId = EtcParsing.Parser("owner_id");
        private string accessToken = EtcParsing.Parser("token");
        private string vkVersion = "5.101";
        private string urlApi = EtcParsing.Parser("url_API");
        private ParserVkApi file = new ParserVkApi();

        internal static string textOnTheWall = GetRandom();

        // Постинг записи
        public string WallPost(string methodName, string parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + parameters + "=" + textOnTheWall + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            System.Net.WebResponse resp = req.GetResponse();

            System.IO.Stream stream = resp.GetResponseStream();                     // Получение json ответа 
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();

            int value;                                                             // Получение значения id и перевод его в строковое значение
            int.TryParse(string.Join("", Out.Where(c => char.IsDigit(c))), out value);
            string postId = value.ToString();

            Console.WriteLine(value + " айди поста");
            Console.WriteLine(textOnTheWall + " Текст до изменения");
            sr.Close();
            return postId;
        }

        //Изменение записи
        public string WallEdit(string methodName, string parameters, string postId, string attachment, string attachmentId)
        {
            string textEdit = GetRandom();
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + "attachments" + "=" + attachment + ownerId + "_" + attachmentId + textEdit + "&" + parameters + "=" + textEdit + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
            Console.WriteLine(textEdit + " Текст после изменения");
            return textEdit;
        }

        //Формирование случайного текста
        private static string GetRandom()
        {
            Random random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }

        //Добавление комментария
        public void AddComment(string methodName, string parameters, string postId)
        {
            string textComment = GetRandom();
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + parameters + "=" + textComment + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
            Console.WriteLine(textComment + " Текст комментария");
        }

        //Добавление лайка
        public void AddLike(string methodName, string type, string postId)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "type=" + type + "&" +"owner_id=" + ownerId + "&" + "item_id" + "=" + postId + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
        }

        //Проверка лайка
        public void CheckLike(string methodName, string type, string postId)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "type=" + type + "&" + "owner_id=" + ownerId + "&" + "item_id" + "=" + postId + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            System.Net.WebResponse resp = req.GetResponse();

            System.IO.Stream stream = resp.GetResponseStream();                     // Получение json ответа 
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();

            Console.WriteLine(Out);
        }

        //Удаление нашего поста
        public void DeletePost(string methodName, string postId)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
        }



        // Постинг файла на стену
        public string GetUploadServer(string methodName)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            System.Net.WebResponse resp = req.GetResponse();

            System.IO.Stream stream = resp.GetResponseStream();                     // Получение json ответа 
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();

            Console.WriteLine(Out + "  Весь ответ");
            sr.Close();
            return Out;
        }
        //public string UploadFileToServer()
        //{
        //    string uploadUrl = file.GetUploadUrl();
        //    string pathToFile = @"C:\Users\p.minchik\Desktop\svinka.png";
        //    var cookies = new CookieContainer();
        //    ServicePointManager.Expect100Continue = false;
        //
        //    var request = (HttpWebRequest)WebRequest.Create(uploadUrl);
        //    request.CookieContainer = cookies;
        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    using (var requestStream = request.GetRequestStream())
        //    using (var writer = new StreamWriter(requestStream))
        //    {
        //        writer.Write("&photo=" + pathToFile);
        //    }
        //
        //    using (var responseStream = request.GetResponse().GetResponseStream())
        //    using (var reader = new StreamReader(responseStream))
        //    {
        //        var result = reader.ReadToEnd();
        //        Console.WriteLine(result);
        //        return result;
        //    }
        //}
    }
}
