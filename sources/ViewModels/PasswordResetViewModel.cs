using SetMeta.Web.Helpers;

namespace SetMeta.Web.ViewModels
{
    public class PasswordResetViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public override bool IsValid()
        {
            return Email.IsEmail();
        }
    }
}