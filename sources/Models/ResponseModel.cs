namespace SetMeta.Web.Models
{
    public class ResponseModel : BaseModel
    {
        public bool IsOk { get; set; }
        public object Result { get; set; }

        public override bool IsValid()
        {
            return Result != null;
        }
    }
}