using SetMeta.Web.Helpers;
using SetMeta.Web.Models;

namespace SetMeta.Web.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }

        public bool IsValidForNewTranslator()
        {
            return !string.IsNullOrEmpty(Name)
                   && Email.IsEmail();
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Password)
                   && !string.IsNullOrEmpty(Name)
                   && Email.IsEmail();
        }

        public static UserViewModel Map(User user)
        {
            var model = new UserViewModel
            {
                Email = user.Email,
                Id = user.PublicId,
                Name = user.Name,
                RoleName = user.RoleName,
                Language = user.Language,
                IsActive = user.IsActive,
                RoleId = user.RoleId
            };
            return model;
        }
    }
}