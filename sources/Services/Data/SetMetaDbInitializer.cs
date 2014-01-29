using System.Data.Entity;

namespace SetMeta.Web.Services.Data
{
    public class SetMetaDbInitializer : MigrateDatabaseToLatestVersion<SetMetaDbContext, SetMetaDbMigrationConfiguration>
    {

    }
}