using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class VisitorUITests : BaseUITest
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

        [Test]
        public void should_login()
        {
            LoginAsUser();

            _browser.Close();
        }

        [Test]
        public void should_signup()
        {
            LogOut();

            GoTo(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_NEW));

            _browser.FindElementById("name").SendKeys("test");
            _browser.FindElementById("email").SendKeys("test@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.Close();
        }

        [Test]
        public void open_contact_and_click_send()
        {
            LogOut();

            GoTo(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_CONTACT));

            _browser.FindElementById("email").SendKeys("email@email.com");
            _browser.FindElementById("info").SendKeys("test"); 

            _browser.FindElementById("btnSend").Click();

            _browser.Close();
        }
    }
}