using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace task_3.vkapi
{
    public class Otvet
    {
        public PhotoResponse response { get; set; }
        public Error error { get; set; }
    }
    public class OtvetForList
    {
        public List<PhotoListResponse> response { get; set; }
        public Error error { get; set; }
    }
    public class PhotoListResponse
    {
        public string id { get; set; }
        public string owner_id { get; set; }
        public string album_id { get; set; }

    }

    public class PhotoResponse
    {
        public int album_id { get; set; }
        public string upload_url { get; set; }
        public int user_id { get; set; }

    }

    public class ServerPhoto
    {
        public string photo { get; set; }
        public string server { get; set; }
        public string hash { get; set; }
    }
    public class Error
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public List<RequestParam> request_params { get; set; }
    }
    public class RequestParam
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class ParserVkApi : VkApiUtils
    {
        private static string GetUploadUrl(string methodName)
        {
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "access_token=" + token + "&" + "v=" + apiVersion);
            //https://api.vk.com/method/photos.getWallUploadServer?access_token=1b3e1a6668a3cf952a48c40900e2e6672f27919b2bdb4e663ab24eb42300776a80fc388001bd30a5653c3&v=5.101
            WebResponse resp = req.GetResponse();

            Stream stream = resp.GetResponseStream();                     // Получение json ответа 
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();

            Console.WriteLine(Out + "  Весь ответ");
            sr.Close();
            Otvet Otvet = JsonConvert.DeserializeObject<Otvet>(Out);

            Console.WriteLine(Otvet.response.upload_url + " ссылка для загрузки изображения");
            return Otvet.response.upload_url;
        }
        private static Tuple<string, string, string> UploadPicture()
        {
            string pathToFile = @"..\..\..\task_3\Files\svinka.png";

            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            Image img = Image.FromFile(pathToFile);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            form.Add(new ByteArrayContent(arr, 0, arr.Count()), "photo", "svinka.png");
            var uploadUrl = GetUploadUrl("photos.getWallUploadServer");
            HttpResponseMessage response = httpClient.PostAsync(uploadUrl, form).Result;

            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(sd + "Ответ после того как загрузили фотку");         //конец пост запроса

            ServerPhoto Otvet = JsonConvert.DeserializeObject<ServerPhoto>(sd);     //парсинг пост запроса
            //Console.WriteLine(Otvet.photo + "джсон объект нашей фотки");
            return Tuple.Create(Otvet.photo, Otvet.server, Otvet.hash);
        }

        public string GetIdPicture(string methodName) 
        {
            var tuple = UploadPicture();
            WebRequest req = WebRequest.Create(urlApi + methodName + "?" + "access_token=" + token + "&" + "v=" + apiVersion + "&" + "photo=" + tuple.Item1 + "&" + "server=" + tuple.Item2 + "&" + "hash=" + tuple.Item3);
            WebResponse resp = req.GetResponse();       //сохранение фотографии и получения айди

            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();

            Console.WriteLine(Out + " ответ после сохранения фотографии");
            sr.Close();
            OtvetForList Otvet = JsonConvert.DeserializeObject<OtvetForList>(Out);
            Console.WriteLine(Otvet.response[0].id);
            return Out;
        }
    }
}
