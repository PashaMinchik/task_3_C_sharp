using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static task_3.parser.EtcParsing;


namespace task_3.config
{
    public class ConfPage
    {
        private static string timeText = Parser("input_data/timeout");
        private static int timeOut = Int32.Parse(timeText);
        public static IWebElement FluentWait(IWebDriver driver, String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            IWebElement elem = wait.Until(x => x.FindElement(By.XPath(locator)));
            return elem;
        }
    }
}
