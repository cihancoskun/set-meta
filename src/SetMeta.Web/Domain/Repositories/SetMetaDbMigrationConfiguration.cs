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

            #region Horoscopes

            AddHoroscopes(context, "Aquarius", "aquarius", "Aquarius");
            AddHoroscopes(context, "Aries", "aries", "Aries");
            AddHoroscopes(context, "Cancer", "cancer", "Cancer");
            AddHoroscopes(context, "Capricorn", "capricorn", "Capricorn");
            AddHoroscopes(context, "Gemini", "gemini", "Gemini");
            AddHoroscopes(context, "Leo", "leo", "Leo");
            AddHoroscopes(context, "Libra", "libra", "Libra");
            AddHoroscopes(context, "Pisces", "pisces", "Pisces");
            AddHoroscopes(context, "Sagittarius", "sagittarius", "Sagittarius");
            AddHoroscopes(context, "Scorpio", "scorpio", "Scorpio");
            AddHoroscopes(context, "Taurus", "taurus", "Taurus");
            AddHoroscopes(context, "Virgo", "virgo", "Virgo");
             
            #endregion

        }

        private void AddHoroscopes(SetMetaDbContext context, string name, string key, string value)
        {
            var horoscope = new Horoscope
            {
                Code = key,
                Name = name,
                Value = value
            };
            context.Horoscopes.Add(horoscope);
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