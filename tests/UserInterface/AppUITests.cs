using System;

using NUnit.Framework;

using SetMeta.Web.Helpers;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class AppUITests : BaseUITest
    {
        [Test]
        public void should_add_new_app()
        {
            CreateApp();

            CloseBrowser();
        }

        [Test]
        public void should_create_new_token()
        {
            CreateApp();

            _browser.FindElementById("btnNewToken").Click();

            CloseBrowser();
        }

        private void CreateApp()
        {
            LogOut();
            GoTo(string.Format("{0}/user/login", BASE_URL));

            _browser.FindElementById("email").SendKeys("mehmet.sabancioglu@gmail.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();

            GoTo(string.Format("{0}/app/new", BASE_URL));

            _browser.FindElementById("name").SendKeys(Guid.NewGuid().ToNoDashString());
            _browser.FindElementById("url").SendKeys(Guid.NewGuid().ToNoDashString());
            _browser.FindElementById("description").SendKeys(Guid.NewGuid().ToNoDashString());
            _browser.FindElementById("frm").Submit();
        }
    }
}
