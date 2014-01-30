using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using SetMeta.Web.Helpers;
using SetMeta.Web.ViewModels;

namespace SetMeta.Web.Controllers
{
    public class DataController : BaseController
    {
        [HttpGet]
        public ActionResult New()
        {
            return Redirect("/data/list");
        }
    }
}