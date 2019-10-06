using System;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using task_3.config;
using task_3.parser;
using System.Configuration;
using System.Collections.Specialized;

namespace task_3.pages
{
    class Factory
    {
        //private static string browserNames = Parser("browser_names/FireFox_names");
        private static IWebDriver driver = null;
        public static IWebDriver CreateDriver()
        {
            string browserName = ConfigurationManager.AppSettings.Get("browser");
            string language = ConfigurationManager.AppSettings.Get("language");

            if (browserName.Equals("FireFox"))
            {
                var options = new FirefoxOptions();
                options.SetPreference("intl.accept_languages", language);
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver(options);
                driver.Manage().Window.Maximize();
            }
            if (browserName.Equals("Chrome"))
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