using System.Linq;
using System.Threading.Tasks;
using SetMeta.Web.Models;

namespace SetMeta.Web.Services
{
    public class MetaDataService : BaseService, IMetaDataService
    {
        public Task<PagedList<MetaData>> GetMetaDatas(string type)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedList<MetaData>> GetMetaDataTypes()
        {
            //var metaDataTypes = _context.Set<MetaData>().Where(x => !x.IsDeleted && x.IsActive).Select(x => x.Type).GroupBy(x => x).ToList().Distinct().ToList();
            return null;
        }
    }

    public interface IMetaDataService
    {
        Task<PagedList<MetaData>> GetMetaDatas(string type);
        Task<PagedList<MetaData>> GetMetaDataTypes();
    }
}