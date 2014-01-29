namespace SetMeta.Web.ViewModels
{
    public class ResponseModel : BaseViewModel
    {
        public bool IsOk { get; set; }
        public object Result { get; set; }

        public override bool IsValid()
        {
            return Result != null;
        }
    }
}