using SetMeta.Web.Helpers;

namespace SetMeta.Web.ViewModels
{
    public class ResetViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public override bool IsValid()
        {
            return Email.IsEmail();
        }
    }
}