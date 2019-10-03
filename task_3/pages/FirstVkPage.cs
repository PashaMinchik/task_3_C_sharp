using OpenQA.Selenium;
using System.Configuration;
using task_3.config;
using task_3.parser;

namespace task_3.pages
{
    public class FirstVkPage
    {
        private IWebDriver driver;
        //private EtcParsing parser = new EtcParsing();
        private ConfPage fluent = new ConfPage();

        public FirstVkPage(IWebDriver driver)
        {
            this.driver = driver; 
        }
        public void InsertLogin()
        {
            string logIn = EtcParsing.Parser("email");
            fluent.Wait(driver, "//input[@id='index_email']").SendKeys(logIn);
        }
        public void InsertPassword()
        {
            string passWord = EtcParsing.Parser("password");
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
