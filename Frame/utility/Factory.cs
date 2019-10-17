using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using SelenoidModalWindows.parser;
using System.Configuration;
using OpenQA.Selenium.Remote;
using System;

namespace SelenoidModalWindows.pages
{
    class Factory
    {
        public static RemoteWebDriver CreateDriver()
        {

            string browserName = ConfigurationManager.AppSettings.Get("browser");
            string urlHub = ConfigurationManager.AppSettings.Get("urlHub");

            DesiredCapabilities capabilities = new DesiredCapabilities(browserName, "", new Platform(PlatformType.Any));
            RemoteWebDriver driver = new RemoteWebDriver(new Uri(urlHub), capabilities);
            return driver;
        }
    }
}