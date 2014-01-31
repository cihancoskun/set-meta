using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class MembershipUITests : BaseUITest
    {
        [Test]
        public void should_login()
        {
            _browser.Navigate().GoToUrl(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_LOGOUT));

            _browser.Navigate().GoToUrl(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_LOGIN));

            _browser.FindElementById("email").SendKeys("test@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.Close();
        }

        [Test]
        public void should_signup()
        {
            _browser.Navigate().GoToUrl(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_LOGOUT));

            _browser.Navigate().GoToUrl(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_NEW));

            _browser.FindElementById("name").SendKeys("test");
            _browser.FindElementById("email").SendKeys("test@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.Close();
        }

        [Test]
        public void should_open_contact()
        {
            _browser.Navigate().GoToUrl(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_LOGOUT));

            _browser.Navigate().GoToUrl(string.Format("{0}{1}", BASE_URL, ACTION_ACCOUNT_CONTACT));
              
            _browser.Close();
        }
    }
}