using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SetMeta.Web.Data.Entities;
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
    }
}