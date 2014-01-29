﻿using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace SetMeta.Web.Helpers
{
    public static class GravatarHelper
    {
        public static string Gravatar(this HtmlHelper helper, string email, int size = 55)
        {
            const string result = "<img src=\"{0}\" alt=\"gravatar\" class=\"gravatar\" />";
            var url = GetGravatarURL(email, size);
            return string.Format(result, url);
        }

        public static string GetGravatarURL(string email, int size = 55)
        {
            return string.Format("//gravatar.com/avatar/{0}?s={1}&r=PG", EncryptMD5(email), size);
        }

        public static string GetGravatarURL(string email, int size, string defaultImagePath)
        {
            return string.Format("{0}&default={1}", GetGravatarURL(email, size), defaultImagePath);
        }

        static string EncryptMD5(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var valueArray = System.Text.Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            return valueArray.Aggregate(string.Empty, (current, t) => current + t.ToString("x2").ToLower());
        }
    }
}