using OpenQA.Selenium;

namespace task_3.config
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
