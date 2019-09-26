using OpenQA.Selenium;
using System;
using task_3.config;
using static task_3.parser.EtcParsing;

namespace task_3.pages
{
    public class FirstVkPage
    {
        private static string logIn = Parser("test_user/email");
        private static string passWord = Parser("test_user/password");
        private static string url = Parser("input_data/url");
        private static string ownerId = Parser("test_user/owner_id");
        
        public void InsertLogin(IWebDriver driver)
        {
            ConfPage.FluentWait(driver, "//input[@id='index_email']").SendKeys(logIn);
        }
        public void InsertPassword(IWebDriver driver)
        {
            ConfPage.FluentWait(driver, "//input[@id='index_pass']").SendKeys(passWord);
        }
        public void ClickButtonSignIn(IWebDriver driver)
        {
            ConfPage.FluentWait(driver, "//button[@id='index_login_button']").Submit();
        }
        public static void VkCom(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
