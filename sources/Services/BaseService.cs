using System.Data.Entity;

using SetMeta.Web.Services.Data;

namespace SetMeta.Web.Services
{
    public class BaseService
    {
        public readonly DbContext _context;

        public BaseService(DbContext context = null)
        {
            if (context == null)
            {
                context = new SetMetaDbContext();
            }

            _context = context;
        }
    }
}