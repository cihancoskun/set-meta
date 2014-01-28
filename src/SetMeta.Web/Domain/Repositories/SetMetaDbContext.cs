using System.Data.Entity;
using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Repositories
{
    public class SetMetaDbContext : DbContext
    {
        public SetMetaDbContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            Database.SetInitializer(new SetMetaDbInitializer());
        }

        public SetMetaDbContext()
            : this("Name=SetMeta")
        {
        }

        public DbSet<Day> Days { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Timezone> Timezones { get; set; }
        public DbSet<Quarter> Quarters { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

    }
}