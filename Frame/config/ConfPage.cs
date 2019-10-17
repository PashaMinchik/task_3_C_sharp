using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SelenoidModalWindows.parser;


namespace SelenoidModalWindows.config
{
    class ConfPage
    {
        public IWebElement Wait(IWebDriver driver, String locator)
        {
            string timeText = ConfigurationManager.AppSettings.Get("timeout");
            int timeOut = int.Parse(timeText);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            IWebElement elem = wait.Until(x => x.FindElement(By.XPath(locator)));
            return elem;
        }
    }
}
