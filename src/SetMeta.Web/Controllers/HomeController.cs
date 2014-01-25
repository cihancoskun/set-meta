using System.Threading.Tasks;
using System.Web.Mvc;
using SetMeta.Web.Domain.Services;

namespace SetMeta.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IReportService _reportService;

        public HomeController(
            IReportService reportService,
            IUserService userService,
            IFormsAuthenticationService formsAuthenticationService)
            : base(userService, formsAuthenticationService)
        {
            _reportService = reportService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ViewResult> Index()
        {
            return View();
        }
    }
}