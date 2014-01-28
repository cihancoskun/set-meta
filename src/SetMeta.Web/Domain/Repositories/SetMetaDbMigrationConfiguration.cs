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

            #region Payment Type

            AddPaymentType(context, "Credit Card", "credit_card");
            AddPaymentType(context, "Cash", "cash");

            #endregion

            #region Currency

            AddCurrency(context, "Afghan Afghani", "AFN");
            AddCurrency(context, "Albanian Lek", "ALL");
            AddCurrency(context, "Armenian Dram", "AMD");
            AddCurrency(context, "Dutch Guilder", "ANG");
            AddCurrency(context, "Angolan Kwanza", "AOA");
            AddCurrency(context, "Argentine Peso", "ARS");
            AddCurrency(context, "Australian Dollar", "AUD");
            AddCurrency(context, "Aruban or Dutch Guilder", "AWG");
            AddCurrency(context, "Azerbaijani New Manat", "AZN");
            AddCurrency(context, "Bosnian Convertible Marka", "BAM");
            AddCurrency(context, "Barbadian or Bajan Dollar", "BBD");
            AddCurrency(context, "Bangladeshi Taka", "BDT");
            AddCurrency(context, "Bulgarian Lev", "BGN");
            AddCurrency(context, "Bahraini Dinar", "BHD");
            AddCurrency(context, "Burundian Franc", "BIF");
            AddCurrency(context, "Bermudian Dollar", "BMD");
            AddCurrency(context, "Bruneian Dollar", "BND");
            AddCurrency(context, "Bolivian Boliviano", "BOB");
            AddCurrency(context, "Brazilian Real", "BRL");
            AddCurrency(context, "Bahamian Dollar", "BSD");
            AddCurrency(context, "Bhutanese Ngultrum", "BTN");
            AddCurrency(context, "Botswana Pula", "BWP");
            AddCurrency(context, "Belarusian Ruble", "BYR");
            AddCurrency(context, "Belizean Dollar", "BZD");
            AddCurrency(context, "Canadian Dollar", "CAD");
            AddCurrency(context, "Congolese Franc", "CDF");
            AddCurrency(context, "Swiss Franc", "CHF");
            AddCurrency(context, "Chilean Peso", "CLP");
            AddCurrency(context, "Chinese Yuan Renminbi", "CNY");
            AddCurrency(context, "Colombian Peso", "COP");
            AddCurrency(context, "Costa Rican Colon", "CRC");
            AddCurrency(context, "Cuban Convertible Peso", "CUC");
            AddCurrency(context, "Cuban Peso", "CUP");
            AddCurrency(context, "Cape Verdean Escudo", "CVE");
            AddCurrency(context, "Czech Koruna", "CZK");
            AddCurrency(context, "Djiboutian Franc", "DJF");
            AddCurrency(context, "Danish Krone", "DKK");
            AddCurrency(context, "Dominican Peso", "DOP");
            AddCurrency(context, "Algerian Dinar", "DZD");
            AddCurrency(context, "Egyptian Pound", "EGP");
            AddCurrency(context, "Eritrean Nakfa", "ERN");
            AddCurrency(context, "Ethiopian Birr", "ETB");
            AddCurrency(context, "Euro", "EUR ");
            AddCurrency(context, "Fijian Dollar", "FJD");
            AddCurrency(context, "Falkland Island Pound", "FKP");
            AddCurrency(context, "British Pound", "GBP");
            AddCurrency(context, "Georgian Lari", "GEL");
            AddCurrency(context, "Guernsey Pound", "GGP");
            AddCurrency(context, "Ghanaian Cedi", "GHS");
            AddCurrency(context, "Gibraltar Pound", "GIP");
            AddCurrency(context, "Gambian Dalasi", "GMD");
            AddCurrency(context, "Guinean Franc", "GNF");
            AddCurrency(context, "Guatemalan Quetzal", "GTQ");
            AddCurrency(context, "Guyanese Dollar", "GYD");
            AddCurrency(context, "Hong Kong Dollar", "HKD");
            AddCurrency(context, "Honduran Lempira", "HNL");
            AddCurrency(context, "Croatian Kuna", "HRK");
            AddCurrency(context, "Haitian Gourde", "HTG");
            AddCurrency(context, "Hungarian Forint", "HUF");
            AddCurrency(context, "Indonesian Rupiah", "IDR");
            AddCurrency(context, "Israeli Shekel", "ILS");
            AddCurrency(context, "Isle of Man Pound", "IMP");
            AddCurrency(context, "Indian Rupee", "INR");
            AddCurrency(context, "Iraqi Dinar", "IQD");
            AddCurrency(context, "Iranian Rial", "IRR");
            AddCurrency(context, "Icelandic Krona", "ISK");
            AddCurrency(context, "Jersey Pound", "JEP");
            AddCurrency(context, "Jamaican Dollar", "JMD");
            AddCurrency(context, "Jordanian Dinar", "JOD");
            AddCurrency(context, "Japanese Yen", "JPY");
            AddCurrency(context, "Kenyan Shilling", "KES");
            AddCurrency(context, "Kyrgyzstani Som", "KGS");
            AddCurrency(context, "Cambodian Riel", "KHR");
            AddCurrency(context, "Comoran Franc", "KMF");
            AddCurrency(context, "North Korean Won", "KPW");
            AddCurrency(context, "South Korean Won", "KRW");
            AddCurrency(context, "Kuwaiti Dinar", "KWD");
            AddCurrency(context, "Caymanian Dollar", "KYD");
            AddCurrency(context, "Kazakhstani Tenge", "KZT");
            AddCurrency(context, "Lao or Laotian Kip", "LAK");
            AddCurrency(context, "Lebanese Pound", "LBP");
            AddCurrency(context, "Sri Lankan Rupee", "LKR");
            AddCurrency(context, "Liberian Dollar", "LRD");
            AddCurrency(context, "Basotho Loti", "LSL");
            AddCurrency(context, "Lithuanian Litas", "LTL");
            AddCurrency(context, "Latvian Lat", "LVL");
            AddCurrency(context, "Libyan Dinar", "LYD");
            AddCurrency(context, "Moroccan Dirham", "MAD");
            AddCurrency(context, "Moldovan Leu", "MDL");
            AddCurrency(context, "Malagasy Ariary", "MGA");
            AddCurrency(context, "Macedonian Denar", "MKD");
            AddCurrency(context, "Burmese Kyat", "MMK");
            AddCurrency(context, "Mongolian Tughrik", "MNT");
            AddCurrency(context, "Macau Pataca", "MOP");
            AddCurrency(context, "Mauritanian Ouguiya", "MRO");
            AddCurrency(context, "Mauritian Rupee", "MUR");
            AddCurrency(context, "Maldivian Rufiyaa", "MVR");
            AddCurrency(context, "Malawian Kwacha", "MWK");
            AddCurrency(context, "Mexican Peso", "MXN");
            AddCurrency(context, "Malaysian Ringgit", "MYR");
            AddCurrency(context, "Mozambican Metical", "MZN");
            AddCurrency(context, "Namibian Dollar", "NAD");
            AddCurrency(context, "Nigerian Naira", "NGN");
            AddCurrency(context, "Nicaraguan Cordoba", "NIO");
            AddCurrency(context, "Norwegian Krone", "NOK");
            AddCurrency(context, "Nepalese Rupee", "NPR");
            AddCurrency(context, "New Zealand Dollar", "NZD");
            AddCurrency(context, "Omani Rial", "OMR");
            AddCurrency(context, "Panamanian Balboa", "PAB");
            AddCurrency(context, "Peruvian Nuevo Sol", "PEN");
            AddCurrency(context, "Papua New Guinean Kina", "PGK");
            AddCurrency(context, "Philippine Peso", "PHP");
            AddCurrency(context, "Pakistani Rupee", "PKR");
            AddCurrency(context, "Polish Zloty", "PLN");
            AddCurrency(context, "Paraguayan Guarani", "PYG");
            AddCurrency(context, "Qatari Riyal", "QAR");
            AddCurrency(context, "Romanian New Leu", "RON");
            AddCurrency(context, "Serbian Dinar", "RSD");
            AddCurrency(context, "Russian Ruble", "RUB");
            AddCurrency(context, "Rwandan Franc", "RWF");
            AddCurrency(context, "Saudi Arabian Riyal", "SAR");
            AddCurrency(context, "Solomon Islander Dollar", "SBD");
            AddCurrency(context, "Seychellois Rupee", "SCR");
            AddCurrency(context, "Sudanese Pound", "SDG");
            AddCurrency(context, "Swedish Krona", "SEK");
            AddCurrency(context, "Singapore Dollar", "SGD");
            AddCurrency(context, "Saint Helenian Pound", "SHP");
            AddCurrency(context, "Sierra Leonean Leone", "SLL");
            AddCurrency(context, "Somali Shilling", "SOS");
            AddCurrency(context, "Seborgan Luigino", "SPL");
            AddCurrency(context, "Surinamese Dollar", "SRD");
            AddCurrency(context, "Sao Tomean Dobra", "STD");
            AddCurrency(context, "Salvadoran Colon", "SVC");
            AddCurrency(context, "Syrian Pound", "SYP");
            AddCurrency(context, "Swazi Lilangeni", "SZL");
            AddCurrency(context, "Thai Baht", "THB");
            AddCurrency(context, "Tajikistani Somoni", "TJS");
            AddCurrency(context, "Turkmenistani Manat", "TMT");
            AddCurrency(context, "Tunisian Dinar", "TND");
            AddCurrency(context, "Tongan Pa'anga", "TOP");
            AddCurrency(context, "Turkish Lira", "TRY");
            AddCurrency(context, "Trinidadian Dollar", "TTD");
            AddCurrency(context, "Tuvaluan Dollar", "TVD");
            AddCurrency(context, "Taiwan New Dollar", "TWD");
            AddCurrency(context, "Tanzanian Shilling", "TZS");
            AddCurrency(context, "Ukrainian Hryvna", "UAH");
            AddCurrency(context, "Ugandan Shilling", "UGX");
            AddCurrency(context, "US Dollar", "USD");
            AddCurrency(context, "Uruguayan Peso", "UYU");
            AddCurrency(context, "Uzbekistani Som", "UZS");
            AddCurrency(context, "Venezuelan Bolivar", "VEF");
            AddCurrency(context, "Vietnamese Dong", "VND");
            AddCurrency(context, "Ni-Vanuatu Vatu", "VUV");
            AddCurrency(context, "Samoan Tala", "WST");
            AddCurrency(context, "Central African CFA Franc BEAC", "XAF");
            AddCurrency(context, "Silver Ounce", "XAG");
            AddCurrency(context, "Gold Ounce", "XAU");
            AddCurrency(context, "Bitcoin", "XBT");
            AddCurrency(context, "East Caribbean Dollar", "XCD");
            AddCurrency(context, "IMF Special Drawing Rights", "XDR");
            AddCurrency(context, "CFA Franc", "XOF");
            AddCurrency(context, "Palladium Ounce", "XPD");
            AddCurrency(context, "CFP Franc", "XPF");
            AddCurrency(context, "Platinum Ounce", "XPT");
            AddCurrency(context, "Yemeni Rial", "YER");
            AddCurrency(context, "South African Rand", "ZAR");
            AddCurrency(context, "Zambian Kwacha", "ZMW");
            AddCurrency(context, "Zimbabwean Dollar", "ZWD ");

            #endregion

            #region Timezones

            AddTimezone(context, "UTC−12:00", "utc_minus_twelve");
            AddTimezone(context, "UTC−11:00", "utc_minus_eleven");
            AddTimezone(context, "UTC−10:00", "utc_minus_ten");
            AddTimezone(context, "UTC−09:30", "utc_minus_half_past_nine");
            AddTimezone(context, "UTC−09:00", "utc_minus_nine");
            AddTimezone(context, "UTC−08:00", "utc_minus_eight");
            AddTimezone(context, "UTC−07:00", "utc_minus_seven");
            AddTimezone(context, "UTC−06:00", "utc_minus_six");
            AddTimezone(context, "UTC−05:00", "utc_minus_five");
            AddTimezone(context, "UTC−04:30", "utc_minus_half_past_four");
            AddTimezone(context, "UTC−04:00", "utc_minus_four");
            AddTimezone(context, "UTC−03:30", "utc_minus_half_past_three");
            AddTimezone(context, "UTC−03:00", "utc_minus_three");
            AddTimezone(context, "UTC−02:00", "utc_minus_two");
            AddTimezone(context, "UTC−01:00", "utc_minus_one");
            AddTimezone(context, "UTC±00:00", "utc_zero");
            AddTimezone(context, "UTC+01:00", "utc_plus_one");
            AddTimezone(context, "UTC+02:00", "utc_plus_two");
            AddTimezone(context, "UTC+03:00", "utc_plus_three");
            AddTimezone(context, "UTC+03:30", "utc_plus_half_past_three");
            AddTimezone(context, "UTC+04:00", "utc_plus_four");
            AddTimezone(context, "UTC+04:30", "utc_plus_half_past_four");
            AddTimezone(context, "UTC+05:00", "utc_plus_five");
            AddTimezone(context, "UTC+05:30", "utc_plus_half_past_five");
            AddTimezone(context, "UTC+05:45", "utc_plus_a_quarter_to_five");
            AddTimezone(context, "UTC+06:00", "utc_plus_six");
            AddTimezone(context, "UTC+06:30", "utc_plus_half_past_six");
            AddTimezone(context, "UTC+07:00", "utc_plus_seven");
            AddTimezone(context, "UTC+08:00", "utc_plus_eight");
            AddTimezone(context, "UTC+08:45", "utc_plus_a_quarter_to_nine");
            AddTimezone(context, "UTC+09:00", "utc_plus_nine");
            AddTimezone(context, "UTC+09:30", "utc_plus_half_past_nine");
            AddTimezone(context, "UTC+10:00", "utc_plus_ten");
            AddTimezone(context, "UTC+10:30", "utc_plus_half_past_ten");
            AddTimezone(context, "UTC+11:00", "utc_plus_eleven");
            AddTimezone(context, "UTC+11:30", "utc_plus_half_past_eleven");
            AddTimezone(context, "UTC+12:00", "utc_plus_twelve");
            AddTimezone(context, "UTC+12:45", "utc_plus_a_quarter_to_thirteen");
            AddTimezone(context, "UTC+13:00", "utc_plus_thirteen");
            AddTimezone(context, "UTC+14:00", "utc_plus_fourteen");

            #endregion

            #region Quarters

            AddQuarter(context, "First Quarter", "first_quarter");
            AddQuarter(context, "Second Quarter", "second_quarter");
            AddQuarter(context, "Third Quarter", "third_quarter");
            AddQuarter(context, "Fourth Quarter", "fourth_quarter");

            #endregion

            #region Credit Card

            AddCreditCard(context, "American Express", "american_express");
            AddCreditCard(context, "Diners Club", "diners_club");
            AddCreditCard(context, "MasterCard", "master_card");
            AddCreditCard(context, "Visa", "visa");

            #endregion

        }

        private void AddCreditCard(SetMetaDbContext context, string name, string key)
        {
            var creditCard = new CreditCard
            {
                Code = key,
                Name = name
            };
            context.CreditCards.Add(creditCard);
        }

        private void AddQuarter(SetMetaDbContext context, string name, string key)
        {
            var quarter = new Quarter
            {
                Code = key,
                Name = name
            };
            context.Quarters.Add(quarter);
        }

        private void AddTimezone(SetMetaDbContext context, string name, string key)
        {
            var timezone = new Timezone
            {
                Code = key,
                Name = name
            };
            context.Timezones.Add(timezone);
        }

        private void AddCurrency(SetMetaDbContext context, string name, string key)
        {
            var currency = new Currency
            {
                Code = key,
                Name = name
            };
            context.Currencies.Add(currency);
        }

        private void AddPaymentType(SetMetaDbContext context, string name, string key)
        {
            var paymentType = new PaymentType
            {
                Code = key,
                Name = name
            };
            context.PaymentTypes.Add(paymentType);
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