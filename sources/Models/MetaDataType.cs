namespace SetMeta.Web.Models
{
    public class MetaDataType : BaseEntity
    {
        public string ParentName { get; set; }
        public string ParentCode { get; set; }
        public string ParentPublicId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}