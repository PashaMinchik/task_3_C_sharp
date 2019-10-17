using OpenQA.Selenium;
using System;
using SelenoidModalWindows.config;
using NUnit.Framework;

namespace SelenoidModalWindows.assertions
{
    class Assertions
    {
        private ConfPage fluent = new ConfPage();

        public void CheckResult(IWebDriver driver, string textResult)
        {
            string text = fluent.Wait(driver, "//p[@id='result']").GetAttribute("innerText");
            Assert.AreEqual(text, textResult);
        }
    }
}
