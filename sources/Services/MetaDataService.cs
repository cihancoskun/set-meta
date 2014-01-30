using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SetMeta.Web.Helpers;
using SetMeta.Web.Models;

namespace SetMeta.Web.Services
{
    public class MetaDataService : BaseService, IMetaDataService
    {
        public Task<PagedList<MetaData>> GetMetaDatas(string typePublicId, int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<MetaData>().Where(x => !x.IsDeleted && x.TypePublicId == typePublicId);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<MetaData>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<List<MetaDataType>> GetMetaDataTypes()
        {
            var items = _context.Set<MetaDataType>().Where(x => !x.IsDeleted && x.IsActive).ToList();
            return Task.FromResult(items);
        }
    }

    public interface IMetaDataService
    {
        Task<PagedList<MetaData>> GetMetaDatas(string typePublicId, int pageNumber);
        Task<List<MetaDataType>> GetMetaDataTypes();
    }
}