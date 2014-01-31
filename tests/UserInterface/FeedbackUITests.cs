using NUnit.Framework;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class FeedbackUITests : BaseUITest
    {
        [Test]
        private void open_feed_back_pop_up()
        {
            LogOut();
            _browser.Navigate().GoToUrl(string.Format("{0}/user/login", BASE_URL));

            _browser.FindElementById("email").SendKeys("mehmet.sabancioglu@gmail.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.FindElementById("btn_open_feed_back").Click();
        }

    }
}