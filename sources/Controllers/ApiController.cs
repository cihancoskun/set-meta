using System.Web.Mvc;

using SetMeta.Web.Helpers;

namespace SetMeta.Web.Controllers
{
    public class ApiController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var headers = filterContext.RequestContext.HttpContext.Request.Headers;

            var authHeader = headers[ConstHelper.Authorization];
            if (authHeader == null) ReturnNotAuthenticated(filterContext);

            var token = authHeader;
            if (string.IsNullOrWhiteSpace(token)) ReturnNotAuthenticated(filterContext);

            //todo:validate token
            

            base.OnActionExecuting(filterContext);
        }
        private static void ReturnNotAuthenticated(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Clear();
            filterContext.RequestContext.HttpContext.Response.Write(@"your request is not authenticated with valid token!<br/>
                                                                      please look at the <a href='/home/api'>api</a> documentation for authenticating this request ...");
            filterContext.RequestContext.HttpContext.Response.End();
        }
    }
}