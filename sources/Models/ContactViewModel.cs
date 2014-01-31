using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetMeta.Web.Models
{
    public class ContactModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }

        public bool IsSend { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Email)
                   && !string.IsNullOrEmpty(Info);
        }
    }
}