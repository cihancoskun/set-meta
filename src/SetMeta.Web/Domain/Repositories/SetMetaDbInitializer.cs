using System.Data.Entity;

namespace SetMeta.Web.Domain.Repositories
{
    public class SetMetaDbInitializer : MigrateDatabaseToLatestVersion<SetMetaDbContext, SetMetaDbMigrationConfiguration>
    {

    }
}