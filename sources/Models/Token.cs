namespace SetMeta.Web.Models
{
    public class Token : BaseEntity
    {
        public long AppId { get; set; }
        public App App { get; set; }

        public string Key { get; set; }
        public long UsageCount { get; set; }
        public bool IsAppActive { get; set; }
    }
}