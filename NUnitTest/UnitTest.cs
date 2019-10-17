using NUnit.Framework;
using SelenoidModalWindows.utility;
using OpenQA.Selenium;
using SelenoidModalWindows.pages;
using OpenQA.Selenium.Remote;
using System;

namespace NUnitTest
{
    [TestFixture]
    class UnitTest
    {
        private static RemoteWebDriver driver = Singleton.GetDriver();
        private FirstPage site = new FirstPage(driver);

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void SetUp()
        {
            site.OpenSite();
        }
        [Test]
        public void Test() 
        {
            site.ClickOnJsAlert();
            site.PassModalWindowJsAlertAndAssert();
            site.ClickOnJsConfirm();
            site.PassModalWindowJsConfirmAndAssert();
            site.ClickOnJsPrompt();
            site.SetText();
            site.PassModalWindowJsPromptAndAssert();
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}
