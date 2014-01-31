using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SetMeta.Web.Helpers;
using SetMeta.Web.Data.Entities;

namespace SetMeta.Web.Services
{
    public class MetaDataService : BaseService, IMetaDataService
    {
        public Task<PagedList<MetaData>> GetMetaDatas(string type, int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<MetaData>().Where(x => !x.IsDeleted && x.TypeCode == type);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<MetaData>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<List<MetaDataType>> GetMetaDataTypes()
        {
            var items = _context.Set<MetaDataType>().Where(x => !x.IsDeleted && x.IsActive).ToList();
            return Task.FromResult(items);
        }

        public Task<bool> IsMetaTypeValid(string type)
        {
            if (string.IsNullOrWhiteSpace(type)) return Task.FromResult(false);

            var isExists = _context.Set<MetaDataType>().Any(x => x.Code == type);

            return Task.FromResult(isExists);
        }
    }

    public interface IMetaDataService
    {
        Task<PagedList<MetaData>> GetMetaDatas(string type, int pageNumber);
        Task<List<MetaDataType>> GetMetaDataTypes();
        Task<bool> IsMetaTypeValid(string type);
    }
}