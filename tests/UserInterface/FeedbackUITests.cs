using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class FeedbackUITests : BaseUITest
    {
        [Test]
        public void open_feed_back_pop_up_and_click_cancel()
        {
            LogOut();

            _browser.FindElementById("btnOpenFeedBack").Click();

            _browser.SwitchTo().Window(_browser.CurrentWindowHandle);

            Wait(1);

            _browser.FindElementById("btnCancelFeedback").Click();

            _browser.Close(); 
        }

        [Test]
        public void open_feed_back_pop_up_and_click_save()
        {
            LogOut();

            Wait(1);

            _browser.FindElementById("btnOpenFeedBack").Click();

            Wait(1);

            _browser.SwitchTo().Window(_browser.CurrentWindowHandle);

            Wait(1);

            _browser.FindElementById("FeedbackEmail").SendKeys("email@email.com");  
            _browser.FindElementById("Feedback").SendKeys("test"); 

            _browser.FindElementById("btnSaveFeedback").Click(); 

            _browser.Close(); 
        }
    }
}