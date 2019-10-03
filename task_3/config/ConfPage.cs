using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using task_3.parser;


namespace task_3.config
{
    class ConfPage
    {
        private EtcParsing parser = new EtcParsing();
        //private static string timeText = Parser("input_data/timeout");
        //private static int timeOut = Int32.Parse(timeText);

        public IWebElement Wait(IWebDriver driver, String locator)
        {
            //string timeText = parser.Parser("timeout");
            string timeText = ConfigurationManager.AppSettings.Get("timeout");
            int timeOut = int.Parse(timeText);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            IWebElement elem = wait.Until(x => x.FindElement(By.XPath(locator)));
            return elem;
        }
    }
}
