using SetMeta.Web.Helpers;

namespace SetMeta.Web.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Password)
                   && Email.IsEmail();
        }
    }
}