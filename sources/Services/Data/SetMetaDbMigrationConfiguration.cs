using System;
using System.Data.Entity.Migrations;
using System.Linq;
using ServiceStack;
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

            #region Quarters

            var quarterPublicId = AddMetaDataType(context, "Quarters");
            AddMetaData(context, "Quarters", quarterPublicId, "First Quarter", "1");
            AddMetaData(context, "Quarters", quarterPublicId, "Second Quarter", "2");
            AddMetaData(context, "Quarters", quarterPublicId, "Third Quarter", "3");
            AddMetaData(context, "Quarters", quarterPublicId, "Fourth Quarter", "4");

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

            #region Days

            var dayPublicId = AddMetaDataType(context, "Days");
            AddMetaData(context, "Days", dayPublicId, "Monday", "1");
            AddMetaData(context, "Days", dayPublicId, "Tuesday", "2");
            AddMetaData(context, "Days", dayPublicId, "Wednesday", "3");
            AddMetaData(context, "Days", dayPublicId, "Thursday", "4");
            AddMetaData(context, "Days", dayPublicId, "Friday", "5");
            AddMetaData(context, "Days", dayPublicId, "Saturday", "6");
            AddMetaData(context, "Days", dayPublicId, "Sunday", "7");

            #endregion

            #region Timezones

            var tiemZonesPublicId = AddMetaDataType(context, "Time Zones");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−12:00", "utc_minus_twelve");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−11:00", "utc_minus_eleven");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−10:00", "utc_minus_ten");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−09:30", "utc_minus_half_past_nine");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−09:00", "utc_minus_nine");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−08:00", "utc_minus_eight");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−07:00", "utc_minus_seven");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−06:00", "utc_minus_six");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−05:00", "utc_minus_five");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−04:30", "utc_minus_half_past_four");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−04:00", "utc_minus_four");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−03:30", "utc_minus_half_past_three");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−03:00", "utc_minus_three");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−02:00", "utc_minus_two");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC−01:00", "utc_minus_one");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC±00:00", "utc_zero");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+01:00", "utc_plus_one");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+02:00", "utc_plus_two");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+03:00", "utc_plus_three");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+03:30", "utc_plus_half_past_three");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+04:00", "utc_plus_four");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+04:30", "utc_plus_half_past_four");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+05:00", "utc_plus_five");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+05:30", "utc_plus_half_past_five");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+05:45", "utc_plus_a_quarter_to_five");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+06:00", "utc_plus_six");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+06:30", "utc_plus_half_past_six");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+07:00", "utc_plus_seven");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+08:00", "utc_plus_eight");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+08:45", "utc_plus_a_quarter_to_nine");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+09:00", "utc_plus_nine");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+09:30", "utc_plus_half_past_nine");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+10:00", "utc_plus_ten");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+10:30", "utc_plus_half_past_ten");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+11:00", "utc_plus_eleven");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+11:30", "utc_plus_half_past_eleven");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+12:00", "utc_plus_twelve");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+12:45", "utc_plus_a_quarter_to_thirteen");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+13:00", "utc_plus_thirteen");
            AddMetaData(context, "Time Zones", tiemZonesPublicId, "UTC+14:00", "utc_plus_fourteen");

            #endregion

            #region Horoscopes

            var horoscopesPublicId = AddMetaDataType(context, "Horoscopes");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Aquarius", "1");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Aries", "2");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Cancer", "3");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Capricorn", "4");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Gemini", "5");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Leo", "6");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Libra", "7");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Pisces", "8");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Sagittarius", "9");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Scorpio", "10");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Taurus", "11");
            AddMetaData(context, "Horoscopes", horoscopesPublicId, "Virgo", "12");

            #endregion

            #region Vehicle Types

            var vehicleTypesPublicId = AddMetaDataType(context, "Vehicle Types");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "Automobile", "1");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "SUVs & Pick-Up Trucks", "2");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "Motorcyles", "3");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "Minivans, Vans & Panelvans", "4");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "ATV", "5");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "UTV", "6");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "Electric Vehicles", "7");
            AddMetaData(context, "Vehicle Types", vehicleTypesPublicId, "RVs & Campers", "8");

            #endregion

            #region Car Brands

            var carBrandsPublicId = AddMetaDataType(context, "Car Brands");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Acura", "www.acura.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Alfa Romeo", "www.alfaromeo.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Aston Martin", "www.astonmartin.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Audi", "www.audi.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Bentley", "www.bentleymotors.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "BMW", "www.bmw.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Bugatti", "www.bugatti.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Buick", "www.buick.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Cadillac", "www.cadillac.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Chery", "www.chery.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Chevrolet", "www.chevrolet.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Chrysler", "www.chrysler.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Citroën", "www.citroen.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Dacia", "www.dacia.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Daewoo", "www.daewoous.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Daihatsu", "www.daihatsu.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Dodge", "www.dodge.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Eagle", "www.eagleautonz.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Ferrari", "www.ferrari.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Fiat", "www.fiat.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Ford", "www.ford.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "GAZ", "eng.gazgroup.ru");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Geely", "www.geely.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Gumpert", "www.gumpert.de");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Hennessey", "www.hennesseyperformance.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Honda", "honda.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Hyundai", "www.hyundai.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Ikco", "www.ikco.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Infiniti", "www.infiniti.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Isuzu", "www.isuzu.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Jaguar", "www.jaguar.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Kia", "www.kia.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Lada", "www.lada.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Lamborghini", "www.lamborghini.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Lancia", "www.lancia.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Lexus", "www.lexus.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Lincoln", "www.lincoln.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Lotus", "www.lotuscars.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Maserati", "www.maserati.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Mazda", "www.mazda.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "McLaren", "www.mclaren.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Mercedes - Benz", "www.mercedes-benz.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Mercury", "www.mercuryvehicles.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "MG", "mg.co.uk");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Mini", "www.mini.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Mitsubishi", "www.mitsubishi-motors.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Nissan", "www.nissan-global.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Oldsmobile", "www.oldsmobile.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Opel", "www.opel.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Peugeot", "www.peugeot.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Pontiac", "www.pontiac.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Porsche", "www.porsche.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Proton", "www.proton.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Renault", "www.renault.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Rolls-Royce", "www.rolls-roycemotorcars.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Saab", "www.saab.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Seat", "www.seat.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Skoda", "www.skoda-auto.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Smart", "www.smart.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Subaru", "www.subaru-global.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Suzuki", "www.suzuki.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Şamil", "www.samil.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Tata", "www.tatamotors.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Toyota", "www.toyota.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Volkswagen", "www.vw.com");
            AddMetaData(context, "Car Brands", carBrandsPublicId, "Volvo", "www.volvo.com");

            #endregion

            #region Payment Type

            var paymentTypePublicId = AddMetaDataType(context, "Payment Type");
            AddMetaData(context, "Payment Type", paymentTypePublicId, "Cash", "1");
            AddMetaData(context, "Payment Type", paymentTypePublicId, "Credit Card", "2");
            AddMetaData(context, "Payment Type", paymentTypePublicId, "Paypal", "3");

            #endregion

            #region Credit Card

            var creditCardPublicId = AddMetaDataType(context, "Credit Card");
            AddMetaData(context, "Credit Card", creditCardPublicId, "American Express", "american_express");
            AddMetaData(context, "Credit Card", creditCardPublicId, "Diners Club", "diners_club");
            AddMetaData(context, "Credit Card", creditCardPublicId, "MasterCard", "master_card");
            AddMetaData(context, "Credit Card", creditCardPublicId, "Visa", "visa");

            #endregion

            #region JobTitles
            var jobTitlesPublicId = AddMetaDataType(context, "JobTitles");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "General Manager", "general_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Software Developer", "software_developer");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Logo Support", "logo_support");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Department Chief", "department_chief");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Secretary", "secretary");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Administrative Manager", "administrative_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Service Manager", "service_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "IT Manager", "it_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Technical Service", "technical_service");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "It Specialist", "it_specialist");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Customer Representative", "customer_representative");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Accounting Personnel", "accounting_personnel");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Customer Services", "customer_services");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Project Manager", "project_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Sales Representative", "sales_representative");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Chief Executive Officer", "chief_executive_officer");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Call Center Operator", "call_center_operator");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Business Development Project Manager", "business_development_project_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Vice General Manager", "vice_general_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Purchasing Manager", "purchasing_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Manager", "manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Assistant Manager", "assistant_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Quality Management Specialist", "quality_management_specialist");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "System Manager", "system_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Accounting Manager", "accounting_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Quality Assurance Manager", "quality_assurance_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "IT Personnel", "it_personnel");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Quality System manager", "quality_system_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "General Secretary", "general_secretary");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Vice President Corporate Affairs", "vice_president_corporate_affairs");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "President Corporate Affairs", "president_corporate_affairs");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Rector", "rector");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Coordinator", "coordinator");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Operation Manager", "operation_manager");
            AddMetaData(context, "JobTitles", jobTitlesPublicId, "Administrator", "administrator");

            #endregion

            #region Sectors

            var sectorPublicId = AddMetaDataType(context, "Sectors");

            AddMetaData(context, "Sectors", sectorPublicId, "Fuel Oil", "fuel_oil");
            AddMetaData(context, "Sectors", sectorPublicId, "Packing", "Packing");
            AddMetaData(context, "Sectors", sectorPublicId, "Banking", "banking");
            AddMetaData(context, "Sectors", sectorPublicId, "Informatics", "informatics");
            AddMetaData(context, "Sectors", sectorPublicId, "Cement", "cement");
            AddMetaData(context, "Sectors", sectorPublicId, "Iron And Steel", "iron_and_steel");
            AddMetaData(context, "Sectors", sectorPublicId, "Pharmacy", "pharmacy");
            AddMetaData(context, "Sectors", sectorPublicId, "Electronics", "electronics");
            AddMetaData(context, "Sectors", sectorPublicId, "Electricity", "electricity");
            AddMetaData(context, "Sectors", sectorPublicId, "Food", "food");
            AddMetaData(context, "Sectors", sectorPublicId, "General", "general");
            AddMetaData(context, "Sectors", sectorPublicId, "Customs", "customs");
            AddMetaData(context, "Sectors", sectorPublicId, "Service", "service");
            AddMetaData(context, "Sectors", sectorPublicId, "Medicine", "medicine");
            AddMetaData(context, "Sectors", sectorPublicId, "Construction", "construction");
            AddMetaData(context, "Sectors", sectorPublicId, "Importation", "importation");
            AddMetaData(context, "Sectors", sectorPublicId, "Chemistry", "chemistry");
            AddMetaData(context, "Sectors", sectorPublicId, "Jeweler", "jeweler");
            AddMetaData(context, "Sectors", sectorPublicId, "Machine", "machine");
            AddMetaData(context, "Sectors", sectorPublicId, "Metal", "metal");
            AddMetaData(context, "Sectors", sectorPublicId, "Transportation", "transportation");
            AddMetaData(context, "Sectors", sectorPublicId, "Chambers", "chamber");
            AddMetaData(context, "Sectors", sectorPublicId, "Automotive", "automotive");
            AddMetaData(context, "Sectors", sectorPublicId, "Plastic", "plastic");
            AddMetaData(context, "Sectors", sectorPublicId, "Health", "health");
            AddMetaData(context, "Sectors", sectorPublicId, "Insurance", "insurance");
            AddMetaData(context, "Sectors", sectorPublicId, "Indepentet Accountent", "indepentet_accountent");
            AddMetaData(context, "Sectors", sectorPublicId, "Tourism", "tourism");
            AddMetaData(context, "Sectors", sectorPublicId, "Shipping", "shipping");
            AddMetaData(context, "Sectors", sectorPublicId, "Structure", "structure");

            #endregion

            #region Departments

            var departmentPublicId = AddMetaDataType(context, "Deparments");

            AddMetaData(context, "Departments", departmentPublicId, "General", "general");
            AddMetaData(context, "Departments", departmentPublicId, "Management", "management");
            AddMetaData(context, "Departments", departmentPublicId, "Technical Service", "technical_service");
            AddMetaData(context, "Departments", departmentPublicId, "Accounting", "accounting");
            AddMetaData(context, "Departments", departmentPublicId, "Software", "software");
            AddMetaData(context, "Departments", departmentPublicId, "Hardware", "hardware");
            AddMetaData(context, "Departments", departmentPublicId, "Logo Support", "logo_support");
            AddMetaData(context, "Departments", departmentPublicId, "Consultant", "consultant");
            AddMetaData(context, "Departments", departmentPublicId, "Sale", "sale");
            AddMetaData(context, "Departments", departmentPublicId, "Purchase", "purchase");
            AddMetaData(context, "Departments", departmentPublicId, "Information Technology", "information_technology");
            AddMetaData(context, "Departments", departmentPublicId, "Personnel Directorate", "personnel_directorate");
            AddMetaData(context, "Departments", departmentPublicId, "Account Executive", "account_executive");
            AddMetaData(context, "Departments", departmentPublicId, "Organization Management", "organization_management");
            AddMetaData(context, "Departments", departmentPublicId, "Shipment", "shipment");
            AddMetaData(context, "Departments", departmentPublicId, "Customer Services", "customer_services");
            AddMetaData(context, "Departments", departmentPublicId, "Insurance", "insurance");
            AddMetaData(context, "Departments", departmentPublicId, "Chancellery", "chancellery");
            AddMetaData(context, "Departments", departmentPublicId, "Marketing", "marketing");
            AddMetaData(context, "Departments", departmentPublicId, "Transportation", "transportation");
            AddMetaData(context, "Departments", departmentPublicId, "Human Resources", "human_resources");

            #endregion

            #region Currency

            var currencyPublicId = AddMetaDataType(context, "Currencies");

            AddMetaData(context, "Currency", currencyPublicId, "Afghan Afghani", "AFN");
            AddMetaData(context, "Currency", currencyPublicId, "Albanian Lek", "ALL");
            AddMetaData(context, "Currency", currencyPublicId, "Armenian Dram", "AMD");
            AddMetaData(context, "Currency", currencyPublicId, "Dutch Guilder", "ANG");
            AddMetaData(context, "Currency", currencyPublicId, "Angolan Kwanza", "AOA");
            AddMetaData(context, "Currency", currencyPublicId, "Argentine Peso", "ARS");
            AddMetaData(context, "Currency", currencyPublicId, "Australian Dollar", "AUD");
            AddMetaData(context, "Currency", currencyPublicId, "Aruban or Dutch Guilder", "AWG");
            AddMetaData(context, "Currency", currencyPublicId, "Azerbaijani New Manat", "AZN");
            AddMetaData(context, "Currency", currencyPublicId, "Bosnian Convertible Marka", "BAM");
            AddMetaData(context, "Currency", currencyPublicId, "Barbadian or Bajan Dollar", "BBD");
            AddMetaData(context, "Currency", currencyPublicId, "Bangladeshi Taka", "BDT");
            AddMetaData(context, "Currency", currencyPublicId, "Bulgarian Lev", "BGN");
            AddMetaData(context, "Currency", currencyPublicId, "Bahraini Dinar", "BHD");
            AddMetaData(context, "Currency", currencyPublicId, "Burundian Franc", "BIF");
            AddMetaData(context, "Currency", currencyPublicId, "Bermudian Dollar", "BMD");
            AddMetaData(context, "Currency", currencyPublicId, "Bruneian Dollar", "BND");
            AddMetaData(context, "Currency", currencyPublicId, "Bolivian Boliviano", "BOB");
            AddMetaData(context, "Currency", currencyPublicId, "Brazilian Real", "BRL");
            AddMetaData(context, "Currency", currencyPublicId, "Bahamian Dollar", "BSD");
            AddMetaData(context, "Currency", currencyPublicId, "Bhutanese Ngultrum", "BTN");
            AddMetaData(context, "Currency", currencyPublicId, "Botswana Pula", "BWP");
            AddMetaData(context, "Currency", currencyPublicId, "Belarusian Ruble", "BYR");
            AddMetaData(context, "Currency", currencyPublicId, "Belizean Dollar", "BZD");
            AddMetaData(context, "Currency", currencyPublicId, "Canadian Dollar", "CAD");
            AddMetaData(context, "Currency", currencyPublicId, "Congolese Franc", "CDF");
            AddMetaData(context, "Currency", currencyPublicId, "Swiss Franc", "CHF");
            AddMetaData(context, "Currency", currencyPublicId, "Chilean Peso", "CLP");
            AddMetaData(context, "Currency", currencyPublicId, "Chinese Yuan Renminbi", "CNY");
            AddMetaData(context, "Currency", currencyPublicId, "Colombian Peso", "COP");
            AddMetaData(context, "Currency", currencyPublicId, "Costa Rican Colon", "CRC");
            AddMetaData(context, "Currency", currencyPublicId, "Cuban Convertible Peso", "CUC");
            AddMetaData(context, "Currency", currencyPublicId, "Cuban Peso", "CUP");
            AddMetaData(context, "Currency", currencyPublicId, "Cape Verdean Escudo", "CVE");
            AddMetaData(context, "Currency", currencyPublicId, "Czech Koruna", "CZK");
            AddMetaData(context, "Currency", currencyPublicId, "Djiboutian Franc", "DJF");
            AddMetaData(context, "Currency", currencyPublicId, "Danish Krone", "DKK");
            AddMetaData(context, "Currency", currencyPublicId, "Dominican Peso", "DOP");
            AddMetaData(context, "Currency", currencyPublicId, "Algerian Dinar", "DZD");
            AddMetaData(context, "Currency", currencyPublicId, "Egyptian Pound", "EGP");
            AddMetaData(context, "Currency", currencyPublicId, "Eritrean Nakfa", "ERN");
            AddMetaData(context, "Currency", currencyPublicId, "Ethiopian Birr", "ETB");
            AddMetaData(context, "Currency", currencyPublicId, "Euro", "EUR ");
            AddMetaData(context, "Currency", currencyPublicId, "Fijian Dollar", "FJD");
            AddMetaData(context, "Currency", currencyPublicId, "Falkland Island Pound", "FKP");
            AddMetaData(context, "Currency", currencyPublicId, "British Pound", "GBP");
            AddMetaData(context, "Currency", currencyPublicId, "Georgian Lari", "GEL");
            AddMetaData(context, "Currency", currencyPublicId, "Guernsey Pound", "GGP");
            AddMetaData(context, "Currency", currencyPublicId, "Ghanaian Cedi", "GHS");
            AddMetaData(context, "Currency", currencyPublicId, "Gibraltar Pound", "GIP");
            AddMetaData(context, "Currency", currencyPublicId, "Gambian Dalasi", "GMD");
            AddMetaData(context, "Currency", currencyPublicId, "Guinean Franc", "GNF");
            AddMetaData(context, "Currency", currencyPublicId, "Guatemalan Quetzal", "GTQ");
            AddMetaData(context, "Currency", currencyPublicId, "Guyanese Dollar", "GYD");
            AddMetaData(context, "Currency", currencyPublicId, "Hong Kong Dollar", "HKD");
            AddMetaData(context, "Currency", currencyPublicId, "Honduran Lempira", "HNL");
            AddMetaData(context, "Currency", currencyPublicId, "Croatian Kuna", "HRK");
            AddMetaData(context, "Currency", currencyPublicId, "Haitian Gourde", "HTG");
            AddMetaData(context, "Currency", currencyPublicId, "Hungarian Forint", "HUF");
            AddMetaData(context, "Currency", currencyPublicId, "Indonesian Rupiah", "IDR");
            AddMetaData(context, "Currency", currencyPublicId, "Israeli Shekel", "ILS");
            AddMetaData(context, "Currency", currencyPublicId, "Isle of Man Pound", "IMP");
            AddMetaData(context, "Currency", currencyPublicId, "Indian Rupee", "INR");
            AddMetaData(context, "Currency", currencyPublicId, "Iraqi Dinar", "IQD");
            AddMetaData(context, "Currency", currencyPublicId, "Iranian Rial", "IRR");
            AddMetaData(context, "Currency", currencyPublicId, "Icelandic Krona", "ISK");
            AddMetaData(context, "Currency", currencyPublicId, "Jersey Pound", "JEP");
            AddMetaData(context, "Currency", currencyPublicId, "Jamaican Dollar", "JMD");
            AddMetaData(context, "Currency", currencyPublicId, "Jordanian Dinar", "JOD");
            AddMetaData(context, "Currency", currencyPublicId, "Japanese Yen", "JPY");
            AddMetaData(context, "Currency", currencyPublicId, "Kenyan Shilling", "KES");
            AddMetaData(context, "Currency", currencyPublicId, "Kyrgyzstani Som", "KGS");
            AddMetaData(context, "Currency", currencyPublicId, "Cambodian Riel", "KHR");
            AddMetaData(context, "Currency", currencyPublicId, "Comoran Franc", "KMF");
            AddMetaData(context, "Currency", currencyPublicId, "North Korean Won", "KPW");
            AddMetaData(context, "Currency", currencyPublicId, "South Korean Won", "KRW");
            AddMetaData(context, "Currency", currencyPublicId, "Kuwaiti Dinar", "KWD");
            AddMetaData(context, "Currency", currencyPublicId, "Caymanian Dollar", "KYD");
            AddMetaData(context, "Currency", currencyPublicId, "Kazakhstani Tenge", "KZT");
            AddMetaData(context, "Currency", currencyPublicId, "Lao or Laotian Kip", "LAK");
            AddMetaData(context, "Currency", currencyPublicId, "Lebanese Pound", "LBP");
            AddMetaData(context, "Currency", currencyPublicId, "Sri Lankan Rupee", "LKR");
            AddMetaData(context, "Currency", currencyPublicId, "Liberian Dollar", "LRD");
            AddMetaData(context, "Currency", currencyPublicId, "Basotho Loti", "LSL");
            AddMetaData(context, "Currency", currencyPublicId, "Lithuanian Litas", "LTL");
            AddMetaData(context, "Currency", currencyPublicId, "Latvian Lat", "LVL");
            AddMetaData(context, "Currency", currencyPublicId, "Libyan Dinar", "LYD");
            AddMetaData(context, "Currency", currencyPublicId, "Moroccan Dirham", "MAD");
            AddMetaData(context, "Currency", currencyPublicId, "Moldovan Leu", "MDL");
            AddMetaData(context, "Currency", currencyPublicId, "Malagasy Ariary", "MGA");
            AddMetaData(context, "Currency", currencyPublicId, "Macedonian Denar", "MKD");
            AddMetaData(context, "Currency", currencyPublicId, "Burmese Kyat", "MMK");
            AddMetaData(context, "Currency", currencyPublicId, "Mongolian Tughrik", "MNT");
            AddMetaData(context, "Currency", currencyPublicId, "Macau Pataca", "MOP");
            AddMetaData(context, "Currency", currencyPublicId, "Mauritanian Ouguiya", "MRO");
            AddMetaData(context, "Currency", currencyPublicId, "Mauritian Rupee", "MUR");
            AddMetaData(context, "Currency", currencyPublicId, "Maldivian Rufiyaa", "MVR");
            AddMetaData(context, "Currency", currencyPublicId, "Malawian Kwacha", "MWK");
            AddMetaData(context, "Currency", currencyPublicId, "Mexican Peso", "MXN");
            AddMetaData(context, "Currency", currencyPublicId, "Malaysian Ringgit", "MYR");
            AddMetaData(context, "Currency", currencyPublicId, "Mozambican Metical", "MZN");
            AddMetaData(context, "Currency", currencyPublicId, "Namibian Dollar", "NAD");
            AddMetaData(context, "Currency", currencyPublicId, "Nigerian Naira", "NGN");
            AddMetaData(context, "Currency", currencyPublicId, "Nicaraguan Cordoba", "NIO");
            AddMetaData(context, "Currency", currencyPublicId, "Norwegian Krone", "NOK");
            AddMetaData(context, "Currency", currencyPublicId, "Nepalese Rupee", "NPR");
            AddMetaData(context, "Currency", currencyPublicId, "New Zealand Dollar", "NZD");
            AddMetaData(context, "Currency", currencyPublicId, "Omani Rial", "OMR");
            AddMetaData(context, "Currency", currencyPublicId, "Panamanian Balboa", "PAB");
            AddMetaData(context, "Currency", currencyPublicId, "Peruvian Nuevo Sol", "PEN");
            AddMetaData(context, "Currency", currencyPublicId, "Papua New Guinean Kina", "PGK");
            AddMetaData(context, "Currency", currencyPublicId, "Philippine Peso", "PHP");
            AddMetaData(context, "Currency", currencyPublicId, "Pakistani Rupee", "PKR");
            AddMetaData(context, "Currency", currencyPublicId, "Polish Zloty", "PLN");
            AddMetaData(context, "Currency", currencyPublicId, "Paraguayan Guarani", "PYG");
            AddMetaData(context, "Currency", currencyPublicId, "Qatari Riyal", "QAR");
            AddMetaData(context, "Currency", currencyPublicId, "Romanian New Leu", "RON");
            AddMetaData(context, "Currency", currencyPublicId, "Serbian Dinar", "RSD");
            AddMetaData(context, "Currency", currencyPublicId, "Russian Ruble", "RUB");
            AddMetaData(context, "Currency", currencyPublicId, "Rwandan Franc", "RWF");
            AddMetaData(context, "Currency", currencyPublicId, "Saudi Arabian Riyal", "SAR");
            AddMetaData(context, "Currency", currencyPublicId, "Solomon Islander Dollar", "SBD");
            AddMetaData(context, "Currency", currencyPublicId, "Seychellois Rupee", "SCR");
            AddMetaData(context, "Currency", currencyPublicId, "Sudanese Pound", "SDG");
            AddMetaData(context, "Currency", currencyPublicId, "Swedish Krona", "SEK");
            AddMetaData(context, "Currency", currencyPublicId, "Singapore Dollar", "SGD");
            AddMetaData(context, "Currency", currencyPublicId, "Saint Helenian Pound", "SHP");
            AddMetaData(context, "Currency", currencyPublicId, "Sierra Leonean Leone", "SLL");
            AddMetaData(context, "Currency", currencyPublicId, "Somali Shilling", "SOS");
            AddMetaData(context, "Currency", currencyPublicId, "Seborgan Luigino", "SPL");
            AddMetaData(context, "Currency", currencyPublicId, "Surinamese Dollar", "SRD");
            AddMetaData(context, "Currency", currencyPublicId, "Sao Tomean Dobra", "STD");
            AddMetaData(context, "Currency", currencyPublicId, "Salvadoran Colon", "SVC");
            AddMetaData(context, "Currency", currencyPublicId, "Syrian Pound", "SYP");
            AddMetaData(context, "Currency", currencyPublicId, "Swazi Lilangeni", "SZL");
            AddMetaData(context, "Currency", currencyPublicId, "Thai Baht", "THB");
            AddMetaData(context, "Currency", currencyPublicId, "Tajikistani Somoni", "TJS");
            AddMetaData(context, "Currency", currencyPublicId, "Turkmenistani Manat", "TMT");
            AddMetaData(context, "Currency", currencyPublicId, "Tunisian Dinar", "TND");
            AddMetaData(context, "Currency", currencyPublicId, "Tongan Pa'anga", "TOP");
            AddMetaData(context, "Currency", currencyPublicId, "Turkish Lira", "TRY");
            AddMetaData(context, "Currency", currencyPublicId, "Trinidadian Dollar", "TTD");
            AddMetaData(context, "Currency", currencyPublicId, "Tuvaluan Dollar", "TVD");
            AddMetaData(context, "Currency", currencyPublicId, "Taiwan New Dollar", "TWD");
            AddMetaData(context, "Currency", currencyPublicId, "Tanzanian Shilling", "TZS");
            AddMetaData(context, "Currency", currencyPublicId, "Ukrainian Hryvna", "UAH");
            AddMetaData(context, "Currency", currencyPublicId, "Ugandan Shilling", "UGX");
            AddMetaData(context, "Currency", currencyPublicId, "US Dollar", "USD");
            AddMetaData(context, "Currency", currencyPublicId, "Uruguayan Peso", "UYU");
            AddMetaData(context, "Currency", currencyPublicId, "Uzbekistani Som", "UZS");
            AddMetaData(context, "Currency", currencyPublicId, "Venezuelan Bolivar", "VEF");
            AddMetaData(context, "Currency", currencyPublicId, "Vietnamese Dong", "VND");
            AddMetaData(context, "Currency", currencyPublicId, "Ni-Vanuatu Vatu", "VUV");
            AddMetaData(context, "Currency", currencyPublicId, "Samoan Tala", "WST");
            AddMetaData(context, "Currency", currencyPublicId, "Central African CFA Franc BEAC", "XAF");
            AddMetaData(context, "Currency", currencyPublicId, "Silver Ounce", "XAG");
            AddMetaData(context, "Currency", currencyPublicId, "Gold Ounce", "XAU");
            AddMetaData(context, "Currency", currencyPublicId, "Bitcoin", "XBT");
            AddMetaData(context, "Currency", currencyPublicId, "East Caribbean Dollar", "XCD");
            AddMetaData(context, "Currency", currencyPublicId, "IMF Special Drawing Rights", "XDR");
            AddMetaData(context, "Currency", currencyPublicId, "CFA Franc", "XOF");
            AddMetaData(context, "Currency", currencyPublicId, "Palladium Ounce", "XPD");
            AddMetaData(context, "Currency", currencyPublicId, "CFP Franc", "XPF");
            AddMetaData(context, "Currency", currencyPublicId, "Platinum Ounce", "XPT");
            AddMetaData(context, "Currency", currencyPublicId, "Yemeni Rial", "YER");
            AddMetaData(context, "Currency", currencyPublicId, "South African Rand", "ZAR");
            AddMetaData(context, "Currency", currencyPublicId, "Zambian Kwacha", "ZMW");
            AddMetaData(context, "Currency", currencyPublicId, "Zimbabwean Dollar", "ZWD ");

            #endregion

            #region Continents

            var continentsPublicId = AddMetaDataType(context, "Continents");
            var asiaPublicId = AddMetaData(context, "Continents", continentsPublicId, "Asia", "1");
            var africaPublicId = AddMetaData(context, "Continents", continentsPublicId, "Africa", "2");
            var antarcticaPublicId = AddMetaData(context, "Continents", continentsPublicId, "Antarctica", "3");
            var europePublicId = AddMetaData(context, "Continents", continentsPublicId, "Europe", "4");
            var oceaniaPublicId = AddMetaData(context, "Continents", continentsPublicId, "Oceania", "5");
            var northAmericaPublicId = AddMetaData(context, "Continents", continentsPublicId, "North America", "6");
            var southAmericaPublicId = AddMetaData(context, "Continents", continentsPublicId, "South America", "7");

            #endregion

            #region Countries

            var countryPublicId = AddMetaDataType(context, "Countries");
            AddMetaData(context, "Countries", countryPublicId, "Afghanistan", "AF", "+93", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Afghanistan", "AF", "+93", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Albania", "AL", "+355", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Algeria", "DZ", "+213", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "American Samoa", "AS", "+1684", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Andorra", "AD", "+376", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Angola", "AO", "+244", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Anguilla", "AI", "+1264", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Antigua and Barbuda", "AG", "+1268", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Argentina", "AR", "+54", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Armenia", "AM", "+374", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Aruba", "AW", "+297", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Australia", "AU", "+61", "Australia");
            AddMetaData(context, "Countries", countryPublicId, "Austria", "AT", "+43", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Azerbaijan", "AZ", "+994", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Bahamas", "BS", "+1242", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Bahrain", "BH", "+973", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Bangladesh", "BD", "+880", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Barbados", "BB", "+1246", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Belarus", "BY", "+375", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Belgium", "BE", "+32", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Belize", "BZ", "+501", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Benin", "BJ", "+229", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Bermuda", "BM", "+1 441", "North America");
            AddMetaData(context, "Countries", countryPublicId, "Bhutan", "BT", " +975", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Bolivia", "BO", "+591", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Bosnia and Herzegovina", "BA", "+387", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Botswana", "BW", "+267", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Brazil", "BR", "+55", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Brunei", "BN", "+673", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Bulgaria", "BG", "+359", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Burkina Faso", "BF", "+226", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Burundi", "BI", "+257", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Cambodia", "KH", "+855", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Cameroon", "CM", "+237", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Canada", "CA", "+1", "North America");
            AddMetaData(context, "Countries", countryPublicId, "Cape Verde", "CV", "+238", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Cayman Islands", "CJ", "+1345", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Central African Republic", "CF", "+236", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Chad", "TD", "+235", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Chile", "CL", "+56", "South America");
            AddMetaData(context, "Countries", countryPublicId, "China", "CN", "+86", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Colombia", "CO", "+57", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Comoros", "KM", "+269", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Democratic Republic of the Congo", "CD", "+243", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Republic of the Congo", "CG", "+242", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Costa Rica", "CR", "+506", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Ivory Coast", "CI", "+225", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Croatia", "HR", "+385", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Cuba", "CU", "+53", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Cyprus", "CY", "+357", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Czech Republic ", "CZ", "+420", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Denmark", "DK", "+45", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Djibouti", "DJ", "+253", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Dominica", "DM", "+1 767", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Dominican Republic", "DO", "+1 809, or 829, 849", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "East Timor", "TL", "+670", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Ecuador", "EC", "+593", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Egypt", "EG", "+20", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "El Salvador", "SV", "+503", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Equatorial Guinea", "GQ", "+240", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Eritrea", "ER", "+291", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Estonia", "EE", "+372", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Ethiopia", "ET", "+251", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Faroe Islands", "FO", "+298", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Fiji", "FJ", "+679", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Finland", "FI", "+358", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "France", "FR", "+33", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "French Guiana", "GF", "+594", "South America");
            AddMetaData(context, "Countries", countryPublicId, "French Polynesia", "PF", "+689", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Gabon", "GA", "+241", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Gambia", "GM", "+220", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Georgia", "GE", "+995", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Germany", "DE", "+49", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Ghana", "GH", "+233", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Great Britain", "GB", "+44", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Greece", "GR", "+30", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Greenland", "GL", "+299", "North America");
            AddMetaData(context, "Countries", countryPublicId, "Grenada", "GD", "+1 473", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Guadeloupe", "GP", "+590", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Guam", "GU", "+1 671", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Guatemala", "GT", "+502", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Guinea", "GN", "+224", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Guinea-Bissau", "GW", "+245", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Guyana", "GY", "+592", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Haiti", "HT", "+509", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Vatican City State", "VA", "+379", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Honduras", "HN", " +504", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Hong Kong", "HK", "+852", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Hungary", "HU", "+36", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Iceland", "IS", "+354", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "India", "IN", "+91", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Indonesia", "ID", "+62", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Iran", "IR", "+98", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Iraq", "IQ", "+964", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Ireland", "IE", "+353", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Israel", "IL", "+972", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Italy", "IT", "+39", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Jamaica", "JM", "+1 876", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Japan", "JP", "+81", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Jordan", "JO", "+962", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Kazakhstan", "KZ", "+7", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Kenya", "KE", "+254", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Kiribati", "KI", "+686", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "North Korea", "KP", "+850", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "South Korea", "KR", "+82", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Kosovo", "KV", "+381", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Kuwait", "KW", "+965", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Kyrgyzstan", "KG", "+996", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Lao", "LS", "+856", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Latvia", "LV", "+371", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Lebanon", "LB", "+961", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Lesotho", "LS", "+266", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Liberia", "LR", "+231", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Libya", "LY", "+218", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Liechtenstein", "LI", "+423", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Lithuania", "LT", "+370", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Luxembourg", "LU", "+352", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Macau", "MO", "+853", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Republic of Macedonia", "MK", "+389", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Madagascar", "MG", "+261", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Malawi", "MW", "+265", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Malaysia", "MY", "+60", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Maldives", "MV", " +960", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Mali", "ML", "+223", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Malta", "MT", "+356", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Marshall Islands", "MH", "+692", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Martinique", "MQ", "+596", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Mauritania", "MR", "+222", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Mauritius", "MU", "+230", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Mexico", "MX", "+52", "North America");
            AddMetaData(context, "Countries", countryPublicId, "Federated States of Micronesia", "FM", "+691", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Moldova", "MD", "+373", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Monaco", "MC", "+377", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Mongolia", "MN", "+976", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Montenegro", "ME", "+382", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Montserrat", "MS", " +1 664", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Morocco", "MA", "+212", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Mozambique", "MZ", "+258", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Myanmar - Burma", "MM", "+95", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Namibia", "NA", "+264", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Nauru", "NR", "+674", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Nepal", "NP", "+977", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Netherlands", "NL", "+31", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Netherlands Antilles", "AN", "+599", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "New Caledonia", "NC", "+687", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "New Zealand", "NZ", "+64", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Nicaragua", "NI", "+505", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Niger", "NE", "+227", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Nigeria", "NG", "+234", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Northern Mariana Islands", "MP", "+1 670", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Norway", "NO", "+47", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Oman", "OM", "+968", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Pakistan", "PK", "+92", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Palau", "PW", "+680", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Palestinian territories", "PS", "+970", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Panama", "PA", "+507", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Papua New Guinea", "PG", "+675", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Paraguay", "PY", "+595", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Peru", "PE", "+51", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Philippines", "PH", "+63", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Pitcairn Islands", "PN", "+870", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Poland", "PL", "+48", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Portugal", "PT", "+351", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Puerto Rico", "PR", "+1 787 or +1 939", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Qatar", "QA", "+974", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Reunion Island", "RE", "+262", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Romania", "RO", "+40", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Russian Federation", "RU", "+7", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Rwanda", "RW", "+250", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Saint Kitts and Nevis", "KN", "+1 869", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Saint Lucia", "LC", "+1 758", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Saint Vincent and the Grenadines", "VC", "+1 784", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Samoa", "WS", "+685", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "San Marino", "SM", " +378", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Sao Tome and Principe", "ST", "+239", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Saudi Arabia", "SA", "+966", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Senegal", "SN", "+221", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Serbia", "RS", "+381", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Seychelles", "SC", "+248", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Sierra Leone", "SL", "+232", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Singapore", "SG", "+65", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Slovakia", "SK", "+421", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Slovenia", "SI", "+386", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Solomon Islands", "SB", "+677", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Somalia", "SO", "+252", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "South Africa", "ZA", "+27", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "South Sudan", "SS", "+211", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Spain", "ES", "+34", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Sri Lanka", "LK", "+94", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Sudan", "SD", "+249", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Suriname", "SR", " +597", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Swaziland", "SZ", " +268", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Sweden", "SE", "+46", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Switzerland", "CH", "+41", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Taiwan", "TW", "+886", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Tajikistan", "TJ", "+922", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "United Republic of Tanzania", "TZ", "+255", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Thailand", "TH", " +66", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Tibet", "TI", "+0086", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Timor-Leste", "TL", "+670", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Togo", "TG", "+228", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Tokelau", "TK", "+690", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Tonga", "TO", "+676", " Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Trinidad and Tobago", "TT", "+1 868", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Tunisia", "TN", "+216", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Turkey", "TR", "+90", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "Turkmenistan", "TM", "+993", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Tuvalu", "TV", "+688", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Uganda", "UG", "+256", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Ukraine", "UA", "+380", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "United Arab Emirates", "AE", "+971", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "United Kingdom", "GB", "+44", "Europe");
            AddMetaData(context, "Countries", countryPublicId, "United States", "US", "+1", "North America");
            AddMetaData(context, "Countries", countryPublicId, "Uruguay", "UY", "+598", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Uzbekistan", "UZ", "+998", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Vanuatu", "VU", "+678", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Venezuela", "VE", "+58", "South America");
            AddMetaData(context, "Countries", countryPublicId, "Vietnam", "VN", "+84", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "British Virgin Islands", "VG", "+1 284", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "US Virgin Islands", "VI", "+1 340", "Oceania");
            AddMetaData(context, "Countries", countryPublicId, "Yemen", "YE", "+967", "Asia", asiaPublicId);
            AddMetaData(context, "Countries", countryPublicId, "Zambia", "ZM", "+260", "Africa");
            AddMetaData(context, "Countries", countryPublicId, "Zimbabwe", "ZW", "+263", "Africa");

            #endregion

            context.SaveChanges();
        }
        private void AddMetaData(SetMetaDbContext context, string type, string typePublicId, string name, string code, string value, string parentName, string parentPublicId = "")
        {
            var metaData = new MetaData
            {
                PublicId = Guid.NewGuid().ToNoDashString(),
                IsActive = true,
                Name = name,
                Code = code,
                TypeName = type,
                TypeCode = type.ToUrlSlug(),
                TypePublicId = typePublicId,
                Value = value,
                ParentName = parentName,
                ParentCode = parentName.ToUrlSlug(),
                ParentPublicId = parentPublicId
            };

            context.MetaDatas.Add(metaData);
        }

        private string AddMetaData(SetMetaDbContext context, string type, string typePublicId, string name, string value)
        {
            var publicId = Guid.NewGuid().ToNoDashString();
            var metaData = new MetaData
            {
                PublicId = publicId,
                IsActive = true,
                Name = name,
                Code = name.ToUrlSlug(),
                TypeName = type,
                TypeCode = type.ToUrlSlug(),
                TypePublicId = typePublicId,
                Value = value
            };

            context.MetaDatas.Add(metaData);

            return publicId;
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