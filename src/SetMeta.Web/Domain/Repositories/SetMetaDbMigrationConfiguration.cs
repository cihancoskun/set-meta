using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
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

            #region JobTitles

            AddJobTitles(context, "General Manager", "general_manager");
            AddJobTitles(context, "Software Developer", "software_developer");
            AddJobTitles(context, "Logo Support", "logo_support");
            AddJobTitles(context, "Department Chief", "department_chief");
            AddJobTitles(context, "Secretary", "secretary");
            AddJobTitles(context, "Administrative Manager", "administrative_manager");
            AddJobTitles(context, "Service Manager", "service_manager");
            AddJobTitles(context, "IT Manager", "it_manager");
            AddJobTitles(context, "Technical Service", "technical_service");
            AddJobTitles(context, "It Specialist", "it_specialist");
            AddJobTitles(context, "Customer Representative", "customer_representative");
            AddJobTitles(context, "Accounting Personnel", "accounting_personnel");
            AddJobTitles(context, "Customer Services", "customer_services");
            AddJobTitles(context, "Project Manager", "project_manager");
            AddJobTitles(context, "Sales Representative", "sales_representative");
            AddJobTitles(context, "Chief Executive Officer", "chief_executive_officer");
            AddJobTitles(context, "Call Center Operator", "call_center_operator");
            AddJobTitles(context, "Business Development Project Manager", "business_development_project_manager");
            AddJobTitles(context, "Vice General Manager", "vice_general_manager");
            AddJobTitles(context, "Purchasing Manager", "purchasing_manager");
            AddJobTitles(context, "Manager", "manager");
            AddJobTitles(context, "Assistant Manager", "assistant_manager");
            AddJobTitles(context, "Quality Management Specialist", "quality_management_specialist");
            AddJobTitles(context, "System Manager", "system_manager");
            AddJobTitles(context, "Accounting Manager", "accounting_manager");
            AddJobTitles(context, "Quality Assurance Manager", "quality_assurance_manager");
            AddJobTitles(context, "IT Personnel", "it_personnel");
            AddJobTitles(context, "Quality System manager", "quality_system_manager");
            AddJobTitles(context, "General Secretary", "general_secretary");
            AddJobTitles(context, "Vice President Corporate Affairs", "vice_president_corporate_affairs");
            AddJobTitles(context, "President Corporate Affairs", "president_corporate_affairs");
            AddJobTitles(context, "Rector", "rector");
            AddJobTitles(context, "Coordinator", "coordinator");
            AddJobTitles(context, "Operation Manager", "operation_manager");
            AddJobTitles(context, "Administrator", "administrator");
            #endregion


            #region Sectors

            AddSectors(context, "Fuel Oil", "fuel_oil");
            AddSectors(context, "Packing", "Packing");
            AddSectors(context, "Banking", "banking");
            AddSectors(context, "Informatics", "informatics");
            AddSectors(context, "Cement", "cement");
            AddSectors(context, "Iron And Steel", "iron_and_steel");
            AddSectors(context, "Pharmacy", "pharmacy");
            AddSectors(context, "Electronics", "electronics");
            AddSectors(context, "Electricity", "electricity");
            AddSectors(context, "Food", "food");
            AddSectors(context, "General", "general");
            AddSectors(context, "Customs", "customs");
            AddSectors(context, "Service", "service");
            AddSectors(context, "Medicine", "medicine");
            AddSectors(context, "Construction", "construction");
            AddSectors(context, "Importation", "importation");
            AddSectors(context, "Chemistry", "chemistry");
            AddSectors(context, "Jeweler", "jeweler");
            AddSectors(context, "Machine", "machine");
            AddSectors(context, "metal", "metal");
            AddSectors(context, "Transportation", "transportation");
            AddSectors(context, "Chambers", "chamber");
            AddSectors(context, "Automotive", "automotive");
            AddSectors(context, "Plastic", "plastic");
            AddSectors(context, "Health", "health");
            AddSectors(context, "Insurance", "insurance");
            AddSectors(context, "Indepentet Accountent", "indepentet_accountent");
            AddSectors(context, "Tourism", "tourism");
            AddSectors(context, "Shipping", "shipping");
            AddSectors(context, "Structure", "structure");
            #endregion



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

        private void AddJobTitles(SetMetaDbContext context, string name, string key)
        {
            var jobTitle = new JobTitle
            {
                Code = key,
                Name = name,
            };
            context.JobTites.Add(jobTitle);
        }


        private void AddSectors(SetMetaDbContext context, string name, string key)
        {
            var sector = new Sector
            {
                Code = key,
                Name = name,
            };
            context.Sectors.Add(sector);
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