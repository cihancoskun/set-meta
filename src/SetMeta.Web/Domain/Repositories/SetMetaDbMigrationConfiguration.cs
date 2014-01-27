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

            #region Car Brands

            AddCarBrand(context, "Acura", "acura", "www.acura.com");
            AddCarBrand(context, "Alfa Romeo", "alfa_romeo", "www.alfaromeo.com");
            AddCarBrand(context, "Aston Martin", "aston_martin", "www.astonmartin.com");
            AddCarBrand(context, "Audi", "audi", "www.audi.com");
            AddCarBrand(context, "Bentley", "bentley", "www.bentleymotors.com");
            AddCarBrand(context, "BMW", "bmw", "www.bmw.com");
            AddCarBrand(context, "Bugatti", "bugatti", "www.bugatti.com");
            AddCarBrand(context, "Buick", "buick", "www.buick.com");
            AddCarBrand(context, "Cadillac", "cadillac", "www.cadillac.com");
            AddCarBrand(context, "Chery", "chery", "www.chery.com");
            AddCarBrand(context, "Chevrolet", "chevrolet", "www.chevrolet.com");
            AddCarBrand(context, "Chrysler", "chrysler", "www.chrysler.com");
            AddCarBrand(context, "Citroën", "citroen", "www.citroen.com");
            AddCarBrand(context, "Dacia", "dacia", "www.dacia.com");
            AddCarBrand(context, "Daewoo", "daewoo", "www.daewoous.com");
            AddCarBrand(context, "Daihatsu", "daihatsu", "www.daihatsu.com");
            AddCarBrand(context, "Dodge", "dodge", "www.dodge.com");
            AddCarBrand(context, "Eagle", "eagle", "www.eagleautonz.com");
            AddCarBrand(context, "Ferrari", "ferrari", "www.ferrari.com");
            AddCarBrand(context, "Fiat", "fiat", "www.fiat.com");
            AddCarBrand(context, "Ford", "ford", "www.ford.com");
            AddCarBrand(context, "GAZ", "gaz", "eng.gazgroup.ru");
            AddCarBrand(context, "Geely", "geely", "www.geely.com");
            AddCarBrand(context, "Gumpert", "gumpert", "www.gumpert.de");
            AddCarBrand(context, "Hennessey", "hennessey", "www.hennesseyperformance.com");
            AddCarBrand(context, "Honda", "honda", "honda.com");
            AddCarBrand(context, "Hyundai", "hyundai", "www.hyundai.com");
            AddCarBrand(context, "Ikco", "ikco", "www.ikco.com");
            AddCarBrand(context, "Infiniti", "infiniti", "www.infiniti.com");
            AddCarBrand(context, "Isuzu", "isuzu", "www.isuzu.com");
            AddCarBrand(context, "Jaguar", "jaguar", "www.jaguar.com");
            AddCarBrand(context, "Kia", "kia", "www.kia.com");
            AddCarBrand(context, "Lada", "lada", "www.lada.com");
            AddCarBrand(context, "Lamborghini", "lamborghini", "www.lamborghini.com");
            AddCarBrand(context, "Lancia", "lancia", "www.lancia.com");
            AddCarBrand(context, "Lexus", "lexus", "www.lexus.com");
            AddCarBrand(context, "Lincoln", "lincoln", "www.lincoln.com");
            AddCarBrand(context, "Lotus", "lotus", "www.lotuscars.com");
            AddCarBrand(context, "Maserati", "maserati", "www.maserati.com");
            AddCarBrand(context, "Mazda", "mazda", "www.mazda.com");
            AddCarBrand(context, "McLaren", "mclaren", "www.mclaren.com");
            AddCarBrand(context, "Mercedes - Benz", "mercedes_benz", "www.mercedes-benz.com");
            AddCarBrand(context, "Mercury", "mercury", "www.mercuryvehicles.com");
            AddCarBrand(context, "MG", "mg", "mg.co.uk");
            AddCarBrand(context, "Mini", "mini", "www.mini.com");
            AddCarBrand(context, "Mitsubishi", "mitsubishi", "www.mitsubishi-motors.com");
            AddCarBrand(context, "Nissan", "nissan", "www.nissan-global.com");
            AddCarBrand(context, "Oldsmobile", "oldsmobile", "www.oldsmobile.com");
            AddCarBrand(context, "Opel", "opel", "www.opel.com");
            AddCarBrand(context, "Peugeot", "peugeot", "www.peugeot.com");
            AddCarBrand(context, "Pontiac", "pontiac", "www.pontiac.com");
            AddCarBrand(context, "Porsche", "porsche", "www.porsche.com");
            AddCarBrand(context, "Proton", "proton", "www.proton.com");
            AddCarBrand(context, "Renault", "renault", "www.renault.com");
            AddCarBrand(context, "Rolls-Royce", "rolls_royce", "www.rolls-roycemotorcars.com");
            AddCarBrand(context, "Saab", "saab", "www.saab.com");
            AddCarBrand(context, "Seat", "seat", "www.seat.com");
            AddCarBrand(context, "Skoda", "skoda", "www.skoda-auto.com");
            AddCarBrand(context, "Smart", "smart", "www.smart.com");
            AddCarBrand(context, "Subaru", "subaru", "www.subaru-global.com");
            AddCarBrand(context, "Suzuki", "suzuki", "www.suzuki.com");
            AddCarBrand(context, "Şamil", "samil", "www.samil.com");
            AddCarBrand(context, "Tata", "tata", "www.tatamotors.com");
            AddCarBrand(context, "Toyota", "toyota", "www.toyota.com");
            AddCarBrand(context, "Volkswagen", "volkswagen", "www.vw.com");
            AddCarBrand(context, "Volvo", "volvo", "www.volvo.com");

            #endregion

        }

        private void AddCarBrand(SetMetaDbContext context, string name, string key, string url)
        {
            var carBrand = new CarBrand
            {
                Code = key,
                Name = name,
                Url = url
            };
            context.CarBrands.Add(carBrand);
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