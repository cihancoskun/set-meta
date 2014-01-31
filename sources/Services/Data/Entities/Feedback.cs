namespace SetMeta.Web.Data.Entities
{
    public class Feedback : BaseEntity
    {
        public string Info { get; set; }
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }
    }
}