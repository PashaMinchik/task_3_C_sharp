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
        private ConfTests confTest = new ConfTests();
        //private VkApiUtils vk = new VkApiUtils();
        private FirstVkPage signInPage = new FirstVkPage(driver);
        //private SecondPostPage secondPage = new SecondPostPage();
        private Assertions assert = new Assertions(driver);

        [TestInitialize]
        public void Initialize()
        {
            signInPage.VkCom();
        }

        [TestMethod]
        public void TestApiVk()
        {
            signInPage.InsertLogin();
            signInPage.InsertPassword();
            signInPage.ClickButtonSignIn();
            //string postId = assert.PostOnTheWallAndCheckText();
            //assert.EditPostAndCheck(driver, postId);
            //assert.AddCommentAndCheck(driver, postId);
            //vk.AddLike("likes.add", "post", postId);
            //vk.CheckLike("likes.isLiked", "post", postId);
            //vk.DeletePost("wall.delete", postId);
        }

        [TestCleanup]
        public void CleanUp()
        {
            confTest.Exit(driver);
            driver = null;
        }
    }
}
