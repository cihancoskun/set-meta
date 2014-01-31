using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using SetMeta.Web.Helpers;
using SetMeta.Web.Data.Entities;
using SetMeta.Web.Models;
using SetMeta.Web.Services;

namespace SetMeta.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAppService _appService;
        private readonly IUserService _userService;
        private readonly IFeedbackService _feedbackService;

        public AdminController(
            IUserService userService,
            IFeedbackService feedbackService,
            IAppService appService)     
        {
            _appService = appService;
            _userService = userService;
            _feedbackService = feedbackService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated
                && User.Identity.GetRoleName() != ConstHelper.Admin)
            {
                filterContext.Result = RedirectToHome();
            }

            base.OnActionExecuting(filterContext);
        }
         [HttpGet]
        public ActionResult Index()
        {
            return Redirect("/admin/apps");
        }
      
        [HttpGet]
        public async Task<ActionResult> Users(int id = 0, int page = 1)
        {
            var pageNumber = page;
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            PagedList<User> users;

            ViewBag.RoleId = id;
            if (ConstHelper.BasicRoles.ContainsValue(id))
            {
                users = await _userService.GetUsersByRoleId(id, pageNumber);
            }
            else
            {
                users = await _userService.GetUsers(pageNumber);
            }

            var list = users.Items.Select(UserModel.Map).ToList();

            var model = new PageModel<UserModel>
            {
                Items = list,
                HasNextPage = users.HasNextPage,
                HasPrevPage = users.HasPreviousPage,
                PageNumber = users.Number,
                ItemCount = users.TotalCount,
                PageCount = users.TotalPageCount
            };
             
            return View(model);
        }
          
        [HttpGet]
        public async Task<ActionResult> Apps(int id = 0)
        {
            var pageNumber = id; 
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var apps = await _appService.GetApps(pageNumber);
            var list = apps.Items.Select(AppModel.Map).ToList();
            var model = new PageModel<AppModel>
            {
                Items = list,
                HasNextPage = apps.HasNextPage,
                HasPrevPage = apps.HasPreviousPage,
                PageNumber = apps.Number,
                ItemCount = apps.TotalCount,
                PageCount = apps.TotalPageCount
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Feedbacks(int id = 0)
        {
            var pageNumber = id;
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var feedbacks = await _feedbackService.GetFeedbacks(pageNumber);
            var list = feedbacks.Items.Select(FeedbackModel.Map).ToList();

            var model = new PageModel<FeedbackModel>
            {
                Items = list,
                HasNextPage = feedbacks.HasNextPage,
                HasPrevPage = feedbacks.HasPreviousPage,
                PageNumber = feedbacks.Number,
                ItemCount = feedbacks.TotalCount,
                PageCount = feedbacks.TotalPageCount
            };

            return View(model);
        }   
    }
}