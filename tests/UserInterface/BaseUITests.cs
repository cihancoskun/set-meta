using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace SetMeta.Tests.UserInterface
{
    public class BaseUITest
    {
        public const string BASE_URL = "http://localhost:8033";

        public const string ACTION_ACCOUNT_LOGIN = "/user/login";
        public const string ACTION_ACCOUNT_LOGOUT = "/user/logout";
        public const string ACTION_ACCOUNT_NEW = "/user/new"; 
         
        public FirefoxDriver _browser;

        [SetUp]
        public void Setup()
        {
            _browser = new FirefoxDriver();
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

        public void CloseBrowser()
        {
            _browser.Close();
        }
    }
}