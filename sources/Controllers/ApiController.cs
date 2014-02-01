using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

using SetMeta.Web.Helpers;
using SetMeta.Web.Services;
using SetMeta.Web.Models;

namespace SetMeta.Web.Controllers
{
    public class ApiController : BaseController
    {
        private readonly IAppService _appService;
        private readonly IMetaDataService _metaDataService;

        public ApiController(
            IAppService appService,
            IMetaDataService metaDataService)
        {
            _appService = appService;
            _metaDataService = metaDataService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<JsonResult> Data(string type, int page = 1)
        {
            var model = new List<MetaDataModel>();

            var isValid = await _metaDataService.IsMetaTypeValid(type);
            if (!isValid) return Json(new { Error = "not valid meta data type!" }, JsonRequestBehavior.AllowGet);

            if (page < 1)
            {
                page = 1;
            }

            var items = await _metaDataService.GetMetaDatas(type, page);
            foreach (var item in items.Items)
            {
                model.Add(new MetaDataModel
                {
                    Code = item.Code,
                    Value = item.Value,
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    Url = item.Url,
                    ParentName = item.ParentName
                });
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var headers = filterContext.RequestContext.HttpContext.Request.Headers;

            var authHeader = headers[ConstHelper.Authorization];
            if (authHeader == null) ReturnNotAuthenticated(filterContext);

            var token = authHeader;
            if (string.IsNullOrWhiteSpace(token)) ReturnNotAuthenticated(filterContext);

            var isTokenValidTask = _appService.IsTokenValid(token);
            isTokenValidTask.Wait();

            if (!isTokenValidTask.Result) ReturnNotAuthenticated(filterContext);

            try
            {
                _appService.LogRequest(token, Request.UserHostAddress, Request.Url.AbsolutePath);
            }
            catch { }


            base.OnActionExecuting(filterContext);
        }

        private static void ReturnNotAuthenticated(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Clear();
            filterContext.RequestContext.HttpContext.Response.Write("your request is not authenticated with valid token!<br/>please look at the <a href='/home/api'>api</a> documentation for authenticating this request ...");
            filterContext.RequestContext.HttpContext.Response.End();
        }
    }
}