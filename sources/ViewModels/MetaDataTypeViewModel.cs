namespace SetMeta.Web.ViewModels
{
    public class MetaDataTypeViewModel : BaseViewModel
    {
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}