using System.Threading.Tasks;
using System.Web.Mvc;

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
        public async Task<ActionResult> List(string id, int page = 1)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Redirect("/data");
            }

            var items = await _metaDataService.GetMetaDatas(id, page);

            return View();
        }
    }
}