using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetMeta.Web.Domain.Entities
{
    public class Bank:BaseMeta
    {
        public string Url { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Teleks { get; set; }
        public string Eft { get; set; }
        public string Swift { get; set; }
    }
}