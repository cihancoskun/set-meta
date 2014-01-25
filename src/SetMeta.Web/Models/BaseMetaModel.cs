namespace SetMeta.Web.Models
{
    public class BaseMetaModel : BaseModel
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public bool IsValidForNew()
        {
            return !string.IsNullOrEmpty(Code)
                   && !string.IsNullOrEmpty(Value);
        }
    }
}