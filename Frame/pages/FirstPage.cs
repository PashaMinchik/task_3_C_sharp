using OpenQA.Selenium;
using System.Configuration;
using SelenoidModalWindows.config;
using SelenoidModalWindows.assertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace SelenoidModalWindows.pages
{
    public class FirstPage
    {
        private IWebDriver driver;
        private ConfPage fluent = new ConfPage();
        private Assertions assert = new Assertions();

        private string randomText = GetRandom();
        public FirstPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void OpenSite()
        {
            string url = ConfigurationManager.AppSettings.Get("url");
            driver.Navigate().GoToUrl(url);
        }
        private IAlert Alert() 
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert;
        }
        public void ClickOnJsAlert()
        {
            fluent.Wait(driver, "//button[@onclick='jsAlert()']").Click();

        }
        public void PassModalWindowJsAlertAndAssert()
        {
            Alert().Accept();
            assert.CheckResult(driver, "You successfuly clicked an alert");
        }
        public void ClickOnJsConfirm()
        {
            fluent.Wait(driver, "//button[@onclick='jsConfirm()']").Click();

        }
        public void PassModalWindowJsConfirmAndAssert()
        {
            Alert().Accept();
            //assert.CheckResult(driver, "You clicked: Ok");
        }
        public void ClickOnJsPrompt()
        {
            fluent.Wait(driver, "//button[@onclick='jsPrompt()']").Click();

        }
        public void PassModalWindowJsPromptAndAssert()
        {
            Alert().Accept();
            assert.CheckResult(driver, "You entered: " + randomText);
        }
        private static string GetRandom()
        {
            Random random = new Random();
            var chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }
        public void SetText()
        {
            Alert().SendKeys(randomText);
        }
    }
}
