using OpenQA.Selenium;
using task_3.pages;
using task_3.parser;
using task_3.vkapi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace task_3.assertions
{
    public class Assertions
    {
        private IWebDriver driver;
        private SecondPostPage checkPostPage = new SecondPostPage();
        private VkApiUtils vk = new VkApiUtils();

        private static ParserEtcApi parser = new ParserEtcApi();
        private string ownerId = parser.GetParameter("ownerId");
        private string picture = parser.GetParameter("picture");

        public Assertions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string PostOnTheWallAndCheckText()
        {
            string idOfPost = vk.WallPost("wall.post", "message");
            checkPostPage.VisibleElement(driver, VkApiUtils.textOnTheWall);
            Assert.AreEqual(VkApiUtils.textOnTheWall, checkPostPage.CheckPost(driver));                        // проверка на соответствие текста
            Assert.IsTrue(checkPostPage.CheckUser(driver).Contains("wpt" + ownerId));                        // Проверка, что запись от правильного пользователя 
            return idOfPost;
        }
        public void EditPostAndCheck(string idOfPost)
        {
            string textOfTheEditedPost = vk.WallEdit("wall.edit", "message", idOfPost, "photo", picture);
            checkPostPage.VisibleElement(driver, textOfTheEditedPost);
            Assert.AreEqual(textOfTheEditedPost, checkPostPage.CheckPostEdit(driver));                               // проверка на соответствие измененного текста
            Assert.IsTrue(checkPostPage.CheckPicture(driver).Contains(picture));                                  // Проверка картинки
        }
        public void AddCommentAndCheck(string idOfPost)
        {
            string textComment = vk.AddComment("wall.createComment", "message", idOfPost);
            checkPostPage.VisibleElement(driver, textComment);
            Assert.IsTrue(checkPostPage.CheckComment(driver) > 0);                                              // проверка того, что комментарий появился
            Assert.IsTrue(checkPostPage.CheckUserComment(driver).Contains(ownerId));                    // проверка, что коммент оставил правильный пользователь
        }
    }
}
