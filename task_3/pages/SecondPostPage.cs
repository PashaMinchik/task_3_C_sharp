using System;
using OpenQA.Selenium;
using task_3.config;
using task_3.vkapi;
//using task_3.vkapi;

namespace task_3.pages
{
    public class SecondPostPage
    {
        private ConfPage fluent = new ConfPage();
        private VkApiUtils vk = new VkApiUtils();
        public string CheckPost(IWebDriver driver)
        {
            string a = fluent.Wait(driver, "//div[@class='wall_post_text zoom_text']").GetAttribute("innerText");
            return a;
        }
        public bool VisibleElement(IWebDriver driver, string text)
        {
            //bool a = ConfPage.FluentWait(driver, "//div[contains(text(), s)]").Displayed;
            string path = "//div[contains(text(), 'value')]";
            string xpath = path.Replace("value", text);
            bool a = fluent.Wait(driver, xpath).Displayed;
            Console.WriteLine("Элемент виден?: " + a);
            return a;
        }
        public string CheckPostEdit(IWebDriver driver)
        {
            string a = fluent.Wait(driver, "//div[@class='wall_post_text']").GetAttribute("innerText");
            Console.WriteLine(a + " Проверка измененного текста");
            return a;
        }
        public string CheckUser(IWebDriver driver)
        {
            string a = fluent.Wait(driver, "//div[@class='wall_post_cont _wall_post_cont']").GetAttribute("id");
            return a;
        }
        public string CheckPicture(IWebDriver driver)
        {
            string a = fluent.Wait(driver, "//a[contains(@class,'page_post_thumb_wrap image')]").GetAttribute("href");
            Console.WriteLine(a + " ссылка на картинку");
            return a;
        }
        public int CheckComment(IWebDriver driver)
        {
            string a = fluent.Wait(driver, "//div[contains(@class,'like_wrap')]//a[contains(@class, 'like_btn comment')]").GetAttribute("data-count");
            int count = int.Parse(a);
            Console.WriteLine(count + " количество комментариев");
            return count;
        }
        public string CheckUserComment(IWebDriver driver)
        {
            string a = fluent.Wait(driver, "//div[@class='reply_content']//a[@class='author']").GetAttribute("data-from-id");
            Console.WriteLine(a + " data-from-id пользователя, что оставил комментарий");
            return a;
        }
        public void AddLike(string postId)
        {
            vk.AddLike("likes.add", "post", postId);
        }

        public void CheckLike(string postId)
        {
            vk.CheckLike("likes.isLiked", "post", postId);
        }
        public void DeletePost(string postId)
        {
            vk.DeletePost("wall.delete", postId);
        }
    }
}
