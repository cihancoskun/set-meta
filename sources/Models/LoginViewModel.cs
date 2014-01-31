using SetMeta.Web.Helpers;

namespace SetMeta.Web.Models
{
    public class LoginModel : BaseModel
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