using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SetMeta.Web.Data.Entities;
using SetMeta.Web.Helpers;
using SetMeta.Web.Models;
using SetMeta.Web.Services;

namespace SetMeta.Web.Controllers
{
    [AllowAnonymous]
    public class DataController : BaseController
    {
        private readonly IMetaDataService _metaDataService;

        public DataController(IMetaDataService metaDataService)
        {
            _metaDataService = metaDataService;
        }

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var items = await _metaDataService.GetMetaDataTypes();
            return View(items);
        }

        [HttpGet]
        public async Task<ActionResult> List()
        { 
            var items = await _metaDataService.GetMetaDataTypes();
            var list = items.Select(MetaDataTypeModel.Map).ToList();
             
            return View(list);
        }
        [HttpGet]
        public async Task<ActionResult> Detail(string type, int page = 1)
        {
            var pageNumber = page;
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var items = await _metaDataService.GetMetaDatas(type, pageNumber);
            var list = items.Items.Select(MetaDataModel.Map).ToList();

            var model = new PageModel<MetaDataModel>
            {
                Items = list,
                HasNextPage = items.HasNextPage,
                HasPrevPage = items.HasPreviousPage,
                PageNumber = items.Number,
                ItemCount = items.TotalCount,
                PageCount = items.TotalPageCount
            };

            return View(model);
        }

    }
}