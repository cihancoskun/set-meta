using System.Web.Mvc;

using SetMeta.Web.Helpers;

namespace SetMeta.Web.Controllers
{
    public class AdminController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated
                && User.Identity.GetRoleName() != ConstHelper.Admin)
            {
                filterContext.Result = RedirectToHome();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}