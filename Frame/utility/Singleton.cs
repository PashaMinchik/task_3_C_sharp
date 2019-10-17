using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SelenoidModalWindows.pages;

namespace SelenoidModalWindows.utility
{
    public class Singleton
    {
        private static RemoteWebDriver driver = null;

        public static RemoteWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = Factory.CreateDriver();
            }
            return driver;
        }
    }
}
