using OpenQA.Selenium;
using task_3.pages;

namespace task_3.utility
{
    public class Singleton
    {
        private static IWebDriver driver = null;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = Factory.CreateDriver();
            }
            return driver;
        }
    }
}
