using System;
using NUnit.Framework; 
using SetMeta.Web.Services.Data;

namespace SetMeta.Tests.UserInterface
{
    [TestFixture]
    public class UrlUITests : BaseUITest
    { 
        [Test]
        public void should_signup()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_NEW));

            _browser.Close();
        }

        [Test]
        public void should_login()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_LOGIN));

            _browser.Close();
        }

        [Test]
        public void should_contact()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_CONTACT));

            _browser.Close();
        }

        [Test]
        public void should_list_meta_data()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_DATA_LIST));

            _browser.Close();
        }

        [Test]
        public void should_new_meta_data()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_DATA_NEW));

            _browser.Close();
        }

        [Test]
        public void should_help()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_HELP));

            _browser.Close();
        }

        [Test]
        public void should_password_reset()
        {
            LogOut();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_PASSWORD_RESET));

            _browser.Close();
        }

        [Test]
        public void should_new_application()
        { 
            LogOut();

            LoginAsAdmin();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_APPLICATION_NEW));

            _browser.Close();
        }

        [Test]
        public void should_user_list_my_application()
        {
            LogOut();

            LoginAsAdmin();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_USER_APPLICATIONS));

            _browser.Close();
        }

        [Test]
        public void should_admin_list_all_application()
        {
            LogOut();

            LoginAsAdmin();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_ADMIN_APPLICATIONS));

            _browser.Close();
        }

        [Test]
        public void should_admin_list_all_users()
        {
            LogOut();

            LoginAsAdmin();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_ADMIN_USERS));

            _browser.Close();
        }

        [Test]
        public void should_admin_list_feedbacks()
        {
            LogOut();

            LoginAsAdmin();

            UrlTest(string.Format("{0}{1}", BASE_URL, ACTION_ADMIN_FEEDBACK));

            _browser.Close();
        }
    }
}