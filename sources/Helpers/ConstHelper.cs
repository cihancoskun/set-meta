using System.Collections.Generic;
using System.Globalization;

namespace SetMeta.Web.Helpers
{
    public static class ConstHelper
    {
        public const string CultureNameTR = "tr-TR";
        public const string CultureNameEN = "en-US";

        public const string tr = "tr";
        public const string en = "en";

        public const string __Lang = "__Lang";

        public const string Authorization = "Authorization";

        private static CultureInfo _cultureTR;
        public static CultureInfo CultureTR { get { return _cultureTR ?? (_cultureTR = new CultureInfo(CultureNameTR)); } }
        private static CultureInfo _cultureEN;
        public static CultureInfo CultureEN { get { return _cultureEN ?? (_cultureEN = new CultureInfo(CultureNameEN)); } }

        public const string Admin = "Admin";
        public const string Developer = "Developer";
        public const string User = "User";
        public static Dictionary<string, int> BasicRoles = new Dictionary<string, int>
        {
            {Admin, 1},
            {Developer, 2},
            {User, 3}
        };

        public const int PageSize = 25;
    }
}
