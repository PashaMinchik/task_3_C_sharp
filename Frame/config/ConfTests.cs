using OpenQA.Selenium;

namespace SelenoidModalWindows.config
{
    public class ConfTests
    {
        private IWebDriver driver;
        public ConfTests(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Exit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
