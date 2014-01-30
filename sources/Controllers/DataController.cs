using System.Web.Mvc;

namespace SetMeta.Web.Controllers
{
    [AllowAnonymous]
    public class DataController : BaseController
    {
        public DataController()
        {
            
        }

        [HttpGet]
        public ActionResult Index()
        {
            //todo get parent metas

            return View();
        }

        [HttpGet]
        public ActionResult List(string id)
        {
            var type = id;
            //todo get parent metas

            return View();
        }
    }
}