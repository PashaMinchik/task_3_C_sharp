using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static task_3.pages.FirstVkPage;
using task_3.pages;
using static task_3.config.ConfTests;
using task_3.utility;
using task_3.vkapi;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver = Singleton.GetDriver();
        private VkApiUtils vk = new VkApiUtils();
        private FirstVkPage signInPage = new FirstVkPage();
        private SecondPostPage checkPostPage = new SecondPostPage();

        [TestInitialize]
        public void Initialize()
        {
            VkCom(driver);
        }

        [TestMethod]
        public void TestApiVk()
        {
            signInPage.InsertLogin(driver);
            signInPage.InsertPassword(driver);
            signInPage.ClickButtonSignIn(driver);
            string idOfPost = vk.WallPost("wall.post", "message");
            Assert.AreEqual(VkApiUtils.textOnTheWall, checkPostPage.CheckPost(driver));          // проверка на соответствие текста
            string idOfTheEditedPost = vk.WallEdit("wall.edit", "message", idOfPost, "photo", "457254586");
            Assert.AreEqual(idOfTheEditedPost, checkPostPage.CheckPost(driver));          // проверка на соответствие измененного текста
            vk.AddComment("wall.createComment", "message", idOfPost);
            vk.AddLike("likes.add", "post", idOfPost);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Exit(driver);
            driver = null;
        }
    }
}
