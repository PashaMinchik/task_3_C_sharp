using System;
using OpenQA.Selenium;
using task_3.config;

namespace task_3.pages
{
    public class SecondPostPage
    {
        public string CheckPost(IWebDriver driver)
        {
            string a = ConfPage.FluentWait(driver, "//div[@class='wall_post_text zoom_text']").GetAttribute("innerText");
            Console.WriteLine(a);
            return a;
        }
        public string CheckComment(IWebDriver driver)
        {
            string a = ConfPage.FluentWait(driver, "//div[contains(@id,'ownerId')]/div[@class='wall_post_text zoom_text']").GetAttribute("innerText");
            Console.WriteLine(a);
            return a;
        }
    }
}
