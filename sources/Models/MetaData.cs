namespace SetMeta.Web.Models
{
    public class MetaData : BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public string TypePublicId { get; set; }

        public string ParentName { get; set; }
        public string ParentCode { get; set; }
        public string ParentPublicId { get; set; }
        
        public string Code { get; set; } 
        public string Value { get; set; }
        
        public string Description { get; set; } 
        public string ImageUrl { get; set; }
        public string Url { get; set; }
    }
}

