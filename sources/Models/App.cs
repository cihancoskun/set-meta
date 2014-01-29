using System.Collections.Generic;

namespace SetMeta.Web.Models
{
    public class App : BaseEntity
    {
        public string UserEmail { get; set; }
        public string UserPublicId { get; set; }

        public string Description { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
        
    }
}