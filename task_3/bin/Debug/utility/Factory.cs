using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using task_3.parser;
using System.Configuration;
using System.Collections.Generic;

namespace task_3.pages
{
    class Factory
    {
        private static IWebDriver driver = null;
        private static ParserEtcApi browserNames = new ParserEtcApi();
        public static IWebDriver CreateDriver()
        {
            string browserName = ConfigurationManager.AppSettings.Get("browser");
            string language = ConfigurationManager.AppSettings.Get("language");

            if (browserNames.GetListParameters("foxNames").Contains(browserName))
                {
                var options = new FirefoxOptions();
                options.SetPreference("intl.accept_languages", language);
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver(options);
                driver.Manage().Window.Maximize();
            }
            if (browserNames.GetListParameters("chromeNames").Contains(browserName))
            {
                var options = new ChromeOptions();
                options.AddArgument("--lang=" + language);
                options.AddArgument("--start-maximized");
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver(options);
            }
            return driver;
        }
    }
}