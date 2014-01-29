namespace SetMeta.Web.ViewModels
{
    public abstract class BaseViewModel
    {
        public string Msg { get; set; }

        public abstract bool IsValid();
    }
}