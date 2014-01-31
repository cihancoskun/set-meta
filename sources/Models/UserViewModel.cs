using SetMeta.Web.Helpers;
using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Models
{
    public class UserModel : BaseModel
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

        public static UserModel Map(User user)
        {
            var model = new UserModel
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