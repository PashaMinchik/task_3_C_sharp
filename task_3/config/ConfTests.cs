using OpenQA.Selenium;

namespace task_3.config
{
    public class ConfTests
    {
        public void Exit(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
    }
}
