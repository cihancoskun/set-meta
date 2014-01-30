namespace SetMeta.Web.ViewModels
{
    public class MetaDataViewModel : BaseViewModel
    {
        public string Type { get; set; }

        public string ParentKey { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Type) 
                   && !string.IsNullOrEmpty(Key) 
                   && !string.IsNullOrEmpty(Value);
        }
    }
}