using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Entities
{
    public class BaseMeta : BaseEntity
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}