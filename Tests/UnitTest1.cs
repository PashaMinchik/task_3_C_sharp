using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_3.pages;
using task_3.assertions;
using task_3.utility;
using task_3.config;
using task_3.vkapi;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static IWebDriver driver = Singleton.GetDriver();
        private ConfTests confTest = new ConfTests(driver);
        private FirstVkPage signInPage = new FirstVkPage(driver);
        private SecondPostPage secondPage = new SecondPostPage();
        private Assertions assertOfSecondPage = new Assertions(driver);
        private ParserVkApi vk = new ParserVkApi();

        [TestInitialize]
        public void Initialize()
        {
            signInPage.VkCom();
        }

        [TestMethod]
        public void TestApiVk()
        {
            //vk.GetIdPicture("photos.saveWallPhoto");
            signInPage.InsertLogin();
            signInPage.InsertPassword();
            signInPage.ClickButtonSignIn();
            string postId = assertOfSecondPage.PostOnTheWallAndCheckText();
            assertOfSecondPage.EditPostAndCheck(postId);
            assertOfSecondPage.AddCommentAndCheck(postId);
            secondPage.AddLike(postId);
            secondPage.CheckLike(postId);
            vk.GetIdPicture("photos.saveWallPhoto");
            secondPage.DeletePost(postId);
        }

        [TestCleanup]
        public void CleanUp()
        {
            confTest.Exit();
            driver = null;
        }
    }
}
