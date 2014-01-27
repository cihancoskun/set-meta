using System;
using System.Data.Entity.Migrations;
using System.Linq;
using SetMeta.Web.Helpers;
using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Repositories
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

            //todo: temporary add myself as admin for tests
            AddAdmin(context, "Max Voloshin", "mx.voloshin@gmail.com");

            #endregion

            #region Months

            AddMonths(context, "January", "january", "1");
            AddMonths(context, "February", "february", "2");
            AddMonths(context, "March", "march", "3");
            AddMonths(context, "April", "april", "4");
            AddMonths(context, "May", "may", "5");
            AddMonths(context, "June", "june", "6");
            AddMonths(context, "July", "july", "7");
            AddMonths(context, "August", "august", "8");
            AddMonths(context, "September", "september", "9");
            AddMonths(context, "October", "october", "10");
            AddMonths(context, "November", "november", "11");
            AddMonths(context, "December", "december", "12");

            #endregion

            #region Vehicle Types

            AddVehicleType(context, "Automobile", "automobile", "1");
            AddVehicleType(context, "SUVs & Pick-Up Trucks", "suvs_pick_up_trucks", "2");
            AddVehicleType(context, "Motorcyles", "motorcycles", "3");
            AddVehicleType(context, "Minivans, Vans & Panelvans", "minivans_vans_panelvans", "4");
            AddVehicleType(context, "ATV", "atv", "5");
            AddVehicleType(context, "UTV", "utv", "6");
            AddVehicleType(context, "Electric Vehicles", "electric_vehicles", "7");
            AddVehicleType(context, "RVs & Campers", "rvs_campers", "8");
            

            #endregion

        }

        private static void AddVehicleType(SetMetaDbContext context, string name, string key, string value)
        {
            var vehicleType = new VehicleType
            {
                Code = key,
                Name = name,
                Value = value
            };
            context.VehicleTypes.Add(vehicleType);
        }

        private void AddMonths(SetMetaDbContext context, string name, string key, string value)
        {
            var month = new Month
            {
                Code = key,
                Name = name,
                Value = value
            };
            context.Months.Add(month);
        }

        private static void AddAdmin(SetMetaDbContext context, string name, string email)
        {
            var user = new User
            {
                Email = email,
                Name = name,
                RoleId = SetLocaleRole.Admin.Value,
                RoleName = SetLocaleRole.Admin.ToString(),
                ImageUrl = GravatarHelper.GetGravatarURL(email, 35),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                LastLoginAt = DateTime.Now,
                IsActive = true
            };
            context.Users.Add(user);
        }
    }
}