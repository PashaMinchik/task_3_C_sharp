using System;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;

public class SignInPage
{
    public static IWebDriver driver
    {
        get
        {
            if (driver == null)
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }
    }
}
