using System;

using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace SetMeta.Tests.UserInterface
{
    public class BaseUITest
    {
        public const string BASE_URL = "http://localhost:8033";

        public const string ACTION_LOGIN = "/user/login";
        public const string ACTION_LOGOUT = "/user/logout";
        public const string ACTION_NEW = "/user/new";
        public const string ACTION_CONTACT = "/home/contact";
        public const string ACTION_DATA_LIST = "/data/list";
        public const string ACTION_DATA_NEW = "/data/new";
        public const string ACTION_HELP = "/home/help";
        public const string ACTION_PASSWORD_RESET = "/user/passwordreset";
        public const string ACTION_APPLICATION_NEW = "/app/new";
        public const string ACTION_USER_APPLICATIONS = "/user/apps";
        public const string ACTION_ADMIN_APPLICATIONS = "/admin/apps";
        public const string ACTION_ADMIN_USERS = "/admin/users";
        public const string ACTION_ADMIN_FEEDBACK = "/admin/feedbacks";
          
        public FirefoxDriver _browser;

        [SetUp]
        public void Setup()
        {
            _browser = new FirefoxDriver();
        }
         
        public void UrlTest(string url)
        { 
            GoTo(url);

            if (_browser.Url != url)
            {
                try
                {
                    Assert.AreEqual(_browser.Url, url);
                }
                finally
                {
                    _browser.Close();
                }
            } 
        }

        public void ClickSave()
        {
            _browser.FindElementById("btn_save").Click();
        }

        public void ClickSaveAndNew()
        {
            _browser.FindElementById("btn_save_and_new").Click();
        }

        public void ClickCancel()
        {
            _browser.FindElementByCssSelector("button[type=reset]").Click();
        }

        public void LoginAsUser()
        { 
            GoTo(string.Format("{0}{1}", BASE_URL, ACTION_LOGIN));

            _browser.FindElementById("email").SendKeys("user@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit(); 
        }
 
        public void LoginAsDev()
        { 
            GoTo(string.Format("{0}{1}", BASE_URL, ACTION_LOGIN));

            _browser.FindElementById("email").SendKeys("dev@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();
        }

        public void LoginAsAdmin()
        { 
            GoTo(string.Format("{0}{1}", BASE_URL, ACTION_LOGIN));

            _browser.FindElementById("email").SendKeys("admin@test.com");
            _browser.FindElementById("password").SendKeys("password");
            _browser.FindElementById("frm").Submit();
        }

        public void LogOut()
        {
            GoTo(string.Format("{0}/user/logout", BASE_URL));
        }

        public void CloseBrowser()
        {
            _browser.Close();
        }

        public void Wait(int second)
        {
            _browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(second));
        }

        public void GoTo(string url)
        {
            _browser.Navigate().GoToUrl(url);
        }

    }
}