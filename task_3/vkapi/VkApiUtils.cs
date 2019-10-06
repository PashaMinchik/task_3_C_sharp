using System;
using System.IO;
using System.Linq;
using System.Net;
using task_3.parser;

namespace task_3.vkapi
{
    public class VkApiUtils
    {
        private static ParserEtcApi parser = new ParserEtcApi();
        private string ownerId = parser.GetParameter("ownerId");
        protected static string token = parser.GetParameter("token");
        //private string apiVersion = parser.GetParameter("apiVersion");
        protected static string apiVersion = "5.101";
        protected static string urlApi = parser.GetParameter("urlApi");

        internal static string textOnTheWall = GetRandom();

        // Постинг записи
        public string WallPost(string methodName, string parameters)
        {
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + parameters + "=" + textOnTheWall + "&" + "access_token=" + token + "&" + "v=" + apiVersion);
            //WebRequest req = WebRequest.Create(https://api.vk.com/method/wall.post?owner_id=381108928&message=textOnTheWall&access_token=1b3e1a6668a3cf952a48c40900e2e6672f27919b2bdb4e663ab24eb42300776a80fc388001bd30a5653c3&v=5.101);
            WebResponse resp = req.GetResponse();

            Stream stream = resp.GetResponseStream();                     // Получение json ответа 
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();

            int.TryParse(string.Join("", Out.Where(c => char.IsDigit(c))), out int value);      // Получение значения id и перевод его в строковое значение
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
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + "attachments" + "=" + attachment + ownerId + "_" + attachmentId + textEdit + "&" + parameters + "=" + textEdit + "&" + "access_token=" + token + "&" + "v=" + apiVersion);
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
        public string AddComment(string methodName, string parameters, string postId)
        {
            string textComment = GetRandom();
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + parameters + "=" + textComment + "&" + "access_token=" + token + "&" + "v=" + apiVersion);
            req.GetResponse();
            Console.WriteLine(textComment + " Текст комментария");
            return textComment;
        }

        //Добавление лайка
        public void AddLike(string methodName, string type, string postId)
        {
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "type=" + type + "&" + "owner_id=" + ownerId + "&" + "item_id" + "=" + postId + "&" + "access_token=" + token + "&" + "v=" + apiVersion);
            req.GetResponse();
        }

        //Проверка лайка
        public void CheckLike(string methodName, string type, string postId)
        {
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "type=" + type + "&" + "owner_id=" + ownerId + "&" + "item_id" + "=" + postId + "&" + "access_token=" + token + "&" + "v=" + apiVersion);
            WebResponse resp = req.GetResponse();

            Stream stream = resp.GetResponseStream();                     // Получение json ответа 
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();

            Console.WriteLine(Out);
            sr.Close();
        }

        //Удаление нашего поста
        public void DeletePost(string methodName, string postId)
        {
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + "access_token=" + token + "&" + "v=" + apiVersion);
            req.GetResponse();
        }

    }

}
