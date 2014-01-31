using System.Data.Entity;

using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Services.Data
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
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<MetaData> MetaDatas { get; set; }
        public DbSet<MetaDataType> MetaDataTypes { get; set; }
    }
}
