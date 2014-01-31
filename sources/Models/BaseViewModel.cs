namespace SetMeta.Web.Models
{
    public abstract class BaseModel
    {
        public string Msg { get; set; }

        public abstract bool IsValid();
    }
}