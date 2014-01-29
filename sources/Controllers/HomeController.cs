using System.Web.Mvc;

namespace SetMeta.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Api()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Error()
        {
            return View();
        }
    }
}