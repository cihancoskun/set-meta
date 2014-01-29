﻿using System.Web.Security;

namespace SetMeta.Web.Services
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string id, string name, string email, string roleName, bool createPersistentCookie);

        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string id, string name, string email, string roleName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(string.Format("{0}|{1}|{2}|{3}", id, name, email, roleName), createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}