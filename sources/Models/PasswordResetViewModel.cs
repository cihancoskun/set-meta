using SetMeta.Web.Helpers;

namespace SetMeta.Web.Models
{
    public class PasswordResetModel : BaseModel
    {
        public string Email { get; set; }

        public override bool IsValid()
        {
            return Email.IsEmail();
        }
    }
}