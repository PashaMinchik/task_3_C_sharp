using OpenQA.Selenium;
using System.Configuration;
using task_3.config;
using task_3.parser;

namespace task_3.pages
{
    public class FirstVkPage
    {
        private IWebDriver driver;
        private ConfPage fluent = new ConfPage();
        private static ParserEtcApi parser = new ParserEtcApi();
        private string email = parser.GetEmail();
        private string passWord = parser.GetPassword();

        public FirstVkPage(IWebDriver driver)
        {
            this.driver = driver; 
        }
        public void InsertLogin()
        {
            fluent.Wait(driver, "//input[@id='index_email']").SendKeys(email);
        }
        public void InsertPassword()
        {
            fluent.Wait(driver, "//input[@id='index_pass']").SendKeys(passWord);
        }
        public void ClickButtonSignIn()
        {
            fluent.Wait(driver, "//button[@id='index_login_button']").Submit();
        }
        public void VkCom()
        {
            string url = ConfigurationManager.AppSettings.Get("url");
            driver.Navigate().GoToUrl(url);
        }
    }
}
