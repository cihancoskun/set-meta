using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class MembershipUITests : BaseUITest
    { 
        [TestFixtureSetUp]
        public void Setup()
        {
            _browser = new FirefoxDriver();
        }

        [Test]
        public void should_login()
        {
            _browser.Navigate().GoToUrl(string.Format("{0}/user/logout", BASE_URL));

            _browser.Navigate().GoToUrl(string.Format("{0}/user/login", BASE_URL));

            _browser.FindElementById("email").SendKeys("test@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.Close();
        }

        [Test]
        public void should_signup()
        {
            _browser.Navigate().GoToUrl(string.Format("{0}/user/logout", BASE_URL));

            _browser.Navigate().GoToUrl(string.Format("{0}/user/new", BASE_URL));

            _browser.FindElementById("name").SendKeys("test");
            _browser.FindElementById("email").SendKeys("test@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            _browser.Close();
        }
    }
}