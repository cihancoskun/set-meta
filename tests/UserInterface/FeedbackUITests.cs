using System.Threading;
using NUnit.Framework;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class FeedbackUITests : BaseUITest
    {
        [Test]
        public void open_feed_back_pop_up_and_click_cancel()
        {
            LogOut(); 
             
            _browser.FindElementById("btn_open_feed_back").Click();

            _browser.SwitchTo().Window(_browser.CurrentWindowHandle);

            Thread.Sleep(2000);

            _browser.FindElementById("btn_feedback_cancel").Click();
              
        }

        [Test]
        public void open_feed_back_pop_up_and_click_save()
        {
            LogOut();

            _browser.FindElementById("btn_open_feed_back").Click();

            _browser.SwitchTo().Window(_browser.CurrentWindowHandle);

            Thread.Sleep(2000);

            _browser.FindElementById("feedbackEmail").SendKeys("email@email.com"); ;
            _browser.FindElementById("txtFeedback").SendKeys("test"); ;
             
            _browser.FindElementById("btn_feedback_save").Click();

        }
    }
}