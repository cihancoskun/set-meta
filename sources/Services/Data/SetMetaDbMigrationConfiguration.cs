using System;
using System.Data.Entity.Migrations;
using System.Linq;

using SetMeta.Web.Helpers;
using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Services.Data
{
    public class SetMetaDbMigrationConfiguration : DbMigrationsConfiguration<SetMetaDbContext>
    {
        public SetMetaDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SetMetaDbContext context)
        {
            if (context.Users.Any()) return;

            #region Users

            AddAdmin(context, "Serdar Büyüktemiz", "hserdarb@gmail.com");
            AddAdmin(context, "Caner Çavuş", "canercvs@gmail.com");
            AddAdmin(context, "Ramiz Sümer", "ramiz.sumerr@gmail.com");
            AddAdmin(context, "Mehmet Sabancıoğlu", "mehmet.sabancioglu@gmail.com");
            AddAdmin(context, "Cihan Çoşkun", "cihancoskun@gmail.com");
            AddAdmin(context, "Kemal Çolak", "kml.colak@gmail.com");
            AddAdmin(context, "Duygu Sevim", "sevimduygu@gmail.com");
            AddAdmin(context, "Max Voloshin", "mx.voloshin@gmail.com");

            #endregion

            #region Months

            var monthPublicId = AddMetaDataType(context, "Months");
            AddMetaData(context, "Months", monthPublicId, "January", "1");
            AddMetaData(context, "Months", monthPublicId, "February", "2");
            AddMetaData(context, "Months", monthPublicId, "March", "3");
            AddMetaData(context, "Months", monthPublicId, "April", "4");
            AddMetaData(context, "Months", monthPublicId, "May", "5");
            AddMetaData(context, "Months", monthPublicId, "June", "6");
            AddMetaData(context, "Months", monthPublicId, "July", "7");
            AddMetaData(context, "Months", monthPublicId, "August", "8");
            AddMetaData(context, "Months", monthPublicId, "September", "9");
            AddMetaData(context, "Months", monthPublicId, "October", "10");
            AddMetaData(context, "Months", monthPublicId, "November", "11");
            AddMetaData(context, "Months", monthPublicId, "December", "12"); 

            #endregion

            #region Countries

            #endregion

            context.SaveChanges();
        }

        private void AddMetaData(SetMetaDbContext context, string type, string typePublicId, string name, string value)
        {
            var metaData = new MetaData
            {
                PublicId = Guid.NewGuid().ToNoDashString(),
                IsActive = true,
                Name = name,
                Code = name.ToUrlSlug(),
                TypeName = type,
                TypeCode = type.ToUrlSlug(),
                TypePublicId = typePublicId,
                Value = value
            };

            context.MetaDatas.Add(metaData);
        }

        private string AddMetaDataType(SetMetaDbContext context, string name)
        {
            var publicId = Guid.NewGuid().ToNoDashString();
            var metaDataType = new MetaDataType
            {
                PublicId = publicId,
                IsActive = true,
                Name = name,
                Code = name.ToUrlSlug()
            };

            context.MetaDataTypes.Add(metaDataType);

            return publicId;
        }

        private static void AddAdmin(SetMetaDbContext context, string name, string email)
        {
            var user = new User
            {
                Email = email,
                PublicId = Guid.NewGuid().ToNoDashString(),
                Name = name,
                RoleId = ConstHelper.BasicRoles[ConstHelper.Admin],
                RoleName = ConstHelper.Admin,
                ImageUrl = GravatarHelper.GetGravatarURL(email),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                LastLoginAt = DateTime.Now,
                IsActive = true
            };
            context.Users.Add(user);
        }
    }
}