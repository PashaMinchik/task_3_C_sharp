using System;
using System.Linq;
using static task_3.parser.EtcParsing;


namespace task_3.vkapi
{
    public class VkApiUtils
    {
        private string ownerId = Parser("test_user/owner_id");
        private string accessToken = Parser("test_user/token");
        private string vkVersion = "5.101";
        private string urlApi = Parser("input_data/url_API");

        public static string textOnTheWall = GetRandom();

        public string WallPost(string methodName, string parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + parameters + "=" + textOnTheWall + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            //"https://api.vk.com/method/wall.post?owner_id=381108928&message=hi&access_token=1b3e1a6668a3cf952a48c40900e2e6672f27919b2bdb4e663ab24eb42300776a80fc388001bd30a5653c3&v=5.101"
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

        public string WallEdit(string methodName, string parameters, string postId, string attachment, string attachmentId)
        {
            string textEdit = GetRandom();
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + "attachments" + "=" + attachment + ownerId + "_" + attachmentId + textEdit + "&" + parameters + "=" + textEdit + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
            Console.WriteLine(textEdit + " Текст после изменения");
            return textEdit;
        }
        private static string GetRandom()
        {
            Random random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }
        public void AddComment(string methodName, string parameters, string postId)
        {
            string textComment = GetRandom();
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + parameters + "=" + textComment + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
            Console.WriteLine(textComment + " Текст комментария");
        }
        public void AddLike(string methodName, string type, string postId)
        {
            //string response = data.Get("https://api.vk.com/method/likes.add?type=post&owner_id=381108928&item_id=43032&access_key=123456_654312_6d103522bc13b790c5&access_token=1b3e1a6668a3cf952a48c40900e2e6672f27919b2bdb4e663ab24eb42300776a80fc388001bd30a5653c3&v=5.101").ToString();
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "type=" + type + "&" +"owner_id=" + ownerId + "&" + "item_id" + "=" + postId + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
        }
        public void DeletePost(string methodName, string postId)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(urlApi + methodName + "?" + "owner_id=" + ownerId + "&" + "post_id" + "=" + postId + "&" + "access_token=" + accessToken + "&" + "v=" + vkVersion);
            req.GetResponse();
        }
    }
}
