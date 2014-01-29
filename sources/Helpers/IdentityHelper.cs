using System;
using System.Security.Principal;

namespace SetMeta.Web.Helpers
{
    public static class IdentityHelper
    {
        public static int GetId(this IIdentity identity)
        {
            return identity.IsAuthenticated ? Convert.ToInt32(identity.Name.Split('|')[0]) : 0;
        }

        public static string GetFullName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[1] : string.Empty;
        }

        public static string GetEmail(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[2] : string.Empty;
        }

        public static string GetRoleName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[3] : string.Empty;
        }
    }
}