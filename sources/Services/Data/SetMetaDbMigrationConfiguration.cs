﻿using System;
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

            #region Continents

            var continentsPublicId = AddMetaDataType(context, "Continents");
            AddMetaData(context, "Continents", continentsPublicId, "Asia", "1");
            AddMetaData(context, "Continents", continentsPublicId, "Africa", "2");
            AddMetaData(context, "Continents", continentsPublicId, "Antarctica", "3");
            AddMetaData(context, "Continents", continentsPublicId, "North America", "4");
            AddMetaData(context, "Continents", continentsPublicId, "Europe", "5");
            AddMetaData(context, "Continents", continentsPublicId, "Oceania", "6");
            AddMetaData(context, "Continents", continentsPublicId, "South America", "7");

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

            #region Countries

            var countryPublicId = AddMetaDataType(context, "Countries");


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

            #region Measurement Units

            #region Stress and Pressure

            var stressAndPressurePublicId = AddMetaDataType(context, "Stress and Pressure");

            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Hectopascal", "hPa");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Kilonewton per square meter", "kN/m²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Kilopascal", "kPa");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Kilogram per square centimeter", "kgf/cm²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Kilogram per square meter", "kgf/m²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "physical atmosphere", "atm");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Planck pressure", "L¯¹MT¯²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Meganewton per square meter", "MN/m²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Megapascal", "Mpa");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Newton per square centimeter", "N/cm²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Newton per square meter", "N/m²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Newton per square millimeter", "N/mm²");
            AddMetaData(context, "Stress and Pressure", stressAndPressurePublicId, "Pascal", "Pa");

            #endregion

            #region Acceleration

            var accelerationPublicId = AddMetaDataType(context, "Acceleration");

            AddMetaData(context, "Acceleration", accelerationPublicId, "Foot per second squared", "ft/s²");
            AddMetaData(context, "Acceleration", accelerationPublicId, "Galileo", "Gal");
            AddMetaData(context, "Acceleration", accelerationPublicId, "meter per second squared", "m/s²");
            AddMetaData(context, "Acceleration", accelerationPublicId, "Millimeter per second squared", "mm/s²");
            AddMetaData(context, "Acceleration", accelerationPublicId, "Kilometer per second squared", "km/s²");
            AddMetaData(context, "Acceleration", accelerationPublicId, "Standard acceleration of free fall on Earth", "gn index");
            AddMetaData(context, "Acceleration", accelerationPublicId, "Inch per second squared", "in/s²");

            #endregion

            #region Area

            var areaPublicId = AddMetaDataType(context, "Area");

            AddMetaData(context, "Area", areaPublicId, "Are", "a");
            AddMetaData(context, "Area", areaPublicId, "Barn", "b");
            AddMetaData(context, "Area", areaPublicId, "Square centimeter", "cm²");
            AddMetaData(context, "Area", areaPublicId, "Square decimeter", "dm²");
            AddMetaData(context, "Area", areaPublicId, "Square foot", "ft²");
            AddMetaData(context, "Area", areaPublicId, "Square inch", "in²");
            AddMetaData(context, "Area", areaPublicId, "Square kilometer", "km²");
            AddMetaData(context, "Area", areaPublicId, "Planck area", "L²");
            AddMetaData(context, "Area", areaPublicId, "Square meter", "m²");
            AddMetaData(context, "Area", areaPublicId, "Square millimeter", "mm²");

            #endregion

            #region Capacity and volume

            var capacityAndVolumePublicId = AddMetaDataType(context, "Capacity and volume");

            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Barrel", "bbl");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Bushel", "bu");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic centimeter", "cc");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "centiliter", "cl");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic decimeter", "dm³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic foot", "ft³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic inch ", "in³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic kilometer", "km³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic meter ", "m³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic millimeter", "mm³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Cubic yard", "yd³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Deciliter", "dl");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Fluid ounce", "oz");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Gallon", "gal");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Hectoliter", "hl");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Planck volume", "L³");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Liter", "l");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Microliter ", "µl");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Milliliter", "ml");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Peck", "pk");
            AddMetaData(context, "Capacity and volume", capacityAndVolumePublicId, "Quart", "qt");

            #endregion

            #region Circular measure

            var circularMeasurePublicId = AddMetaDataType(context, "Circular measure");

            AddMetaData(context, "Circular measure", circularMeasurePublicId, "circumference", "circle");
            AddMetaData(context, "Circular measure", circularMeasurePublicId, "Degree", "deg");
            AddMetaData(context, "Circular measure", circularMeasurePublicId, "Grade", "grad");
            AddMetaData(context, "Circular measure", circularMeasurePublicId, "Radian", "rad");

            #endregion

            #region Computer Storage

            var computerStoragePublicId = AddMetaDataType(context, "Computer Storage");

            AddMetaData(context, "Computer Storage", computerStoragePublicId, "Exbibyte [exabyte]", "Eb [EiB]");
            AddMetaData(context, "Computer Storage", computerStoragePublicId, "Exabit [exbibit]", "Ebit [Eibit]");
            AddMetaData(context, "Computer storage", computerStoragePublicId, "Gigabyte [gibibyte]", "Gb [GiB]");
            AddMetaData(context, "Computer storage", computerStoragePublicId, " Gigabit [gibibit]", "Gbit [Gibit]");
            AddMetaData(context, "Computer Storage", computerStoragePublicId, "megabyte [mebibyte]", "Mb [MiB] ");
            AddMetaData(context, "Computer Storage", computerStoragePublicId, "megabit [mebibit]", "Mbit [Mibit]");
            AddMetaData(context, "Computer Storage", computerStoragePublicId, "Storage length in meters", "m");
            AddMetaData(context, "computer Storage", computerStoragePublicId, "Terabit [tebibit] ", "Tbit [Tibit]");
            AddMetaData(context, "Computer Storage", computerStoragePublicId, "Terabyte [tebibyte] ", "Tb [TiB]");
            AddMetaData(context, "Computer storage", computerStoragePublicId, "Kilobyte [kibybyte]", "Kb [KiB]");
            AddMetaData(context, "Computer storage", computerStoragePublicId, "Kilobit [kibibit]", "Kbit [Kibit]");

            #endregion

            #region Data transfer rate

            var dataTransferRatePublicId = AddMetaDataType(context, "Data transfer rate");

            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "byte per second", "B/s ");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Gigabyte per second", "GB/s");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Gigabit per second", "Gbps");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Kilobyte per second", "KB/s");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Megabyte per second", "MB/s");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "megabit per second", "Mbps");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Terabyte per second", "TB/s");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Terabit per second (Tbps)", "Tbps");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "bit per second", "bps");
            AddMetaData(context, "Data transfer rate", dataTransferRatePublicId, "Kilobit per second", "kbps");

            #endregion

            #region Density

            var densityPublicId = AddMetaDataType(context, "Density");

            AddMetaData(context, "Density", densityPublicId, "Planck density", "L¯³M ");
            AddMetaData(context, "Density", densityPublicId, "Pound per cubic foot", "lb/ft³");
            AddMetaData(context, "Density", densityPublicId, "Pound per U.S. gallon", "lb/gal");
            AddMetaData(context, "Density", densityPublicId, "Pound per cubic inch", "lb/in³");
            AddMetaData(context, "Density", densityPublicId, "Pound per cubic yard", "lb/yd³");
            AddMetaData(context, "Density", densityPublicId, "Milligram per cubic meter", "mg/m³");
            AddMetaData(context, "Density", densityPublicId, "Ounce per cubic foot ", "oz/ft³");
            AddMetaData(context, "Density", densityPublicId, "Ounce per cubic inch ", "oz/in³");
            AddMetaData(context, "Density", densityPublicId, "Ounce per cubic yard ", "oz/yd³");
            AddMetaData(context, "Density", densityPublicId, "Gram per litre", "g/L");
            AddMetaData(context, "Density", densityPublicId, " Gram per cubic meter", "g/m³");
            AddMetaData(context, "Density", densityPublicId, "Kilogram per litre", "kg/L");
            AddMetaData(context, "Density", densityPublicId, "Kilogram per cubic meter", "kg/m³");
            AddMetaData(context, "Density", densityPublicId, " Gram per millilitre", "g/mL");

            #endregion

            #region Distance and Length

            var distanceAndLenghtPublicId = AddMetaDataType(context, "Distance and Length");

            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "astronomical unit", "au");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Cable length", "cbl");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Gunter's (surveyors') chain", "ch");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Ramsden's (engineers') chain", "ch");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Centimeter", "cm");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Cubit", "cu");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Decimeter", "dm");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Fathom", "fath");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Foot", "ft");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Horizontal pitch", "HP");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Hand", "hd");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Horizontal pitch", "HP");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Inch", "in");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Kilometer", "km");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Planck length", "L");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "meter", "m");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Mile", "mi");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Millimeter", "mm");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Nanometer", "nm");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Palm", "plm");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Parsec", "pc");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Point", "pt");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Pixel", "px");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Rod", "rd");
            AddMetaData(context, "Distance and Length", distanceAndLenghtPublicId, "Yard", "yd");

            #endregion

            #region Energy and Work

            var energyAndWorkPublicId = AddMetaDataType(context, "Energy and Work");

            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "billion barrel of oil equivalent", "BBOE");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "barrel of oil equivalent", "BOE");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "British Thermal Unit", "BTU");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Calorie", "cal");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Electronvolt", "eV");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Foot-Pound", "ft*lbs");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Gigatonne of oil equivalent", "Gtoe");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Joule", "J");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Kilobarrel of oil equivalent", "kBOE");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Kilojoule", "kJ");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Kilowatt hour", "kW*h");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Kilocalorie", "kcal");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Planck energy", "L²MT¯²");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Megajoule", "MJ");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Million BTU", "MMBTU");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "megacalorie", "Mcal");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "megatonne of oil equivalent", "Mtoe");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Metre-kilogram", "mkg");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Watt hour", "W*h");
            AddMetaData(context, "Energy and Work", energyAndWorkPublicId, "Watt second", "W*s");

            #endregion

            #region Flow rate by mass

            var flowRateByMassPublicId = AddMetaDataType(context, "Flow rate by mass");

            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Gram per day", "g/day");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Gram per hour", "g/hour");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Kilogram per day", "kg/day");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Kilogram per hour", "kg/hour");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Kilogram per minute", "kg/min");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Kilogram per second", "kg/s");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Kilogram per year", "kg/year");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Pound per day", "lb/day");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Pound per second", "lb/s");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Pound per minute", "lb/min");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Pound per hour", "lb/hour");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, " Gram per minute", "g/min");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Gram per second", "g/s");
            AddMetaData(context, "Flow rate by mass", flowRateByMassPublicId, "Gram per year", "g/year");

            #endregion

            #region Flow rate by volume

            var flowRateByVolumePublicId = AddMetaDataType(context, "Flow rate by volume");

            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic foot per second", "ft³/s");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic foot per minute", "ft³/min");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic foot per hour", "ft³/hour");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic foot per day", "ft³/day");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic foot per year", "ft³/year");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic inch per second", "in³/s");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic inch per minute", "in³/min");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic inch per hour", "in³/hour");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic inch per day", "in³/day");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic inch per year", "in³/year");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic meter per second", "m³/s");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic meter per minute", "m³/min");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic meter per hour", "m³/hour");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic meter per day", "m³/day");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Cubic meter per year", "m³/year");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "U.S. gallon per day", "gal/day");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "U.S. gallon per year", "gal/year");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "U.S. gallon per hour", "gph");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "U.S. gallon per minute", "gpm");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "U.S. gallon per second", "gps");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Liter per day", "l/day");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Liter per hour", "l/hour");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Liter per minute", "l/min");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Liter per second", "l/s");
            AddMetaData(context, "Flow rate by volume", flowRateByVolumePublicId, "Liter per year", "l/year");

            #endregion

            #region Force

            var forcePublicId = AddMetaDataType(context, "Force");

            AddMetaData(context, "Force", forcePublicId, "Dyne", "dyn");
            AddMetaData(context, "Force", forcePublicId, "Grave-force", "Gf");
            AddMetaData(context, "Force", forcePublicId, "Kilonewton", "kN");
            AddMetaData(context, "Force", forcePublicId, "Kilogram-force", "kgf");
            AddMetaData(context, "Force", forcePublicId, "Kilopond", "kp");
            AddMetaData(context, "Force", forcePublicId, "Planck force", "LMT²");
            AddMetaData(context, "Force", forcePublicId, "Pound-force", "lbf");
            AddMetaData(context, "Force", forcePublicId, "Meganewton", "MN");
            AddMetaData(context, "Force", forcePublicId, "Milligrave-force", "mGf");
            AddMetaData(context, "Force", forcePublicId, "Millinewton", "mN");
            AddMetaData(context, "Force", forcePublicId, "Micronewton ", "µN");
            AddMetaData(context, "Force", forcePublicId, "Newton", "N");

            #endregion

            #region Franctions and Percent

            var franctionsAndPercentPublicId = AddMetaDataType(context, "Franctions and Percent");

            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Atto", "a");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Centil", "c");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Deci", "d");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Deka", "da");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Exa", "E");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Femto", "f");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Hecto", "h");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Half", "½");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Kilo", "k");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Mega", "M");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "milli", "m");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Micro", "µ; mc");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Micromole ", "µmol");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Millimole", "mmol");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Mole", "mol");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Nano", "n");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Tera", "T");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Permille", "‰");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Yotta", "Y");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Zetta", "Z");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Percent", "%");
            AddMetaData(context, "Franctions and Percent", franctionsAndPercentPublicId, "Giga", "g");

            #endregion

            #region Mass and weight

            var massAndWeightPublicId = AddMetaDataType(context, "Mass and weight");

            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Carat", "ct");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Dram", "dr");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Pennyweight", "dwt");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Gram", "g");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Grain", "gr");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Kilogram", "kg");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Pound", "lb");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Planck mass", "M");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Microgram", "mcg");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Milligram", "mg");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "Ounce ", "oz");
            AddMetaData(context, "Mass and weight", massAndWeightPublicId, "atomic mass unit", "amu");

            #endregion

            #region Power

            var powerPublicId = AddMetaDataType(context, "Power");

            AddMetaData(context, "Power", powerPublicId, "Foot pound-force per second", "ft*lbf/s");
            AddMetaData(context, "Power", powerPublicId, "Horsepower, electric", "hp(E)");
            AddMetaData(context, "Power", powerPublicId, "Horsepower, mechanical (imperial)", "hp(I) ");
            AddMetaData(context, "Power", powerPublicId, "Horsepower, metric", "hp(M)");
            AddMetaData(context, "Power", powerPublicId, "Horsepower, boiler", "hp(S)");
            AddMetaData(context, "Power", powerPublicId, "Kilowatt", "kW");
            AddMetaData(context, "Power", powerPublicId, "Planck power", "L²MT¯³");
            AddMetaData(context, "Power", powerPublicId, "Megawatt", "MW");
            AddMetaData(context, "Power", powerPublicId, "Volt-ampere", "VA");
            AddMetaData(context, "Power", powerPublicId, "Watt", "W");

            #endregion

            #region Radiation

            var radiationPublicId = AddMetaDataType(context, "Radiation");

            AddMetaData(context, "Radiation", radiationPublicId, "Centigrey", "cGy");
            AddMetaData(context, "Radiation", radiationPublicId, "Gray", "Gy");
            AddMetaData(context, "Radiation", radiationPublicId, "Milligray", "mGy");
            AddMetaData(context, "Radiation", radiationPublicId, "Milliroentgen", "mR");
            AddMetaData(context, "Radiation", radiationPublicId, "Millisievert", "mSv");
            AddMetaData(context, "Radiation", radiationPublicId, "Microgray ", "µGy");
            AddMetaData(context, "Radiation", radiationPublicId, "Microroentgen ", "µR");
            AddMetaData(context, "Radiation", radiationPublicId, "Microsievert ", "µSv");

            #endregion

            #region Radioactivity

            var radioActivityPublicId = AddMetaDataType(context, "Radioactivity");

            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Becquerel ", "Bq");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Curie", "Ci");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Disintegrations per minute", "dpm");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Gigabecquerel", "GBq");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Kilobecquerel", "kBq");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Megabecquerel", "MBq");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Millicurie", "mCi");
            AddMetaData(context, "Radioactivity", radioActivityPublicId, "Microcurie", "µCi");

            #endregion

            #region Speed

            var speedPublicId = AddMetaDataType(context, "Speed");

            AddMetaData(context, "Speed", speedPublicId, "Kilometer per second", "km/s");
            AddMetaData(context, "Speed", speedPublicId, "meter per second", "m/s");
            AddMetaData(context, "Speed", speedPublicId, "Mile per hour ", "mph");
            AddMetaData(context, "Speed", speedPublicId, "Mile per hour ", "mph");

            #endregion

            #region Temperature

            var temperaturePublicId = AddMetaDataType(context, "Temperature");

            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Celsius ", "°C ");
            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Delisle ", "°D ");
            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Fahrenheit ", "°F ");
            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Newton ", "°N ");
            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Rømer ", "°R ");
            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Rankine ", "°RØ");
            AddMetaData(context, "Temperature", temperaturePublicId, "degrees Reaumur", "°Re ");
            AddMetaData(context, "Temperature", temperaturePublicId, "Kelvin", "K");

            #endregion

            #region Time

            var timePublicId = AddMetaDataType(context, "Time");

            AddMetaData(context, "Time", timePublicId, "Minute", "min");
            AddMetaData(context, "Time", timePublicId, "Second", "s");
            AddMetaData(context, "Time", timePublicId, "Planck time", "T");

            #endregion

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