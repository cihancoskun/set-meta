using System;
using System.Threading.Tasks;
using System.Web.Mvc;

using SetMeta.Web.Helpers;
using SetMeta.Web.Services;
using SetMeta.Web.Models;

namespace SetMeta.Web.Controllers
{
    public class AppController : BaseController
    {
        private readonly IAppService _appService;
        public AppController(
            IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToHome();
            }

            var entity = await _appService.Get(id);
            if (entity == null)
            {
                return Redirect("/user/apps");
            }

            ViewBag.IsActive = entity.IsActive;

            var model = AppModel.Map(entity);
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new AppModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> New(AppModel model)
        {
            if (!model.IsValid())
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            model.CreatedBy = User.Identity.GetId();
            model.Email = User.Identity.GetEmail();
            model.Id = Guid.NewGuid().ToNoDashString();

            var isCreated = await _appService.CreateApp(model);
            if (!isCreated)
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            return Redirect(string.Format("/app/detail/{0}", model.Id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> NewToken(string appId)
        {
            var result = new ResponseModel { IsOk = false };

            var token = new TokenModel
            {
                CreationDate = DateTime.Now,
                UsageCount = 0,
                Token = Guid.NewGuid().ToNoDashString(),
                AppId = appId,
                CreatedBy = User.Identity.GetId()
            };

            var isOk = await _appService.CreateToken(token);
            if (!isOk) return Json(result, JsonRequestBehavior.DenyGet);

            result.IsOk = true;
            result.Result = token;

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> ChangeStatus(string id, bool isActive)
        {
            var model = new ResponseModel { IsOk = false };
            if (string.IsNullOrWhiteSpace(id))
            {
                return Json(model, JsonRequestBehavior.DenyGet);
            }

            model.IsOk = await _appService.ChangeStatus(id, isActive);

            return Json(model, JsonRequestBehavior.DenyGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteToken(string token)
        {
            var model = new ResponseModel { IsOk = false };
            if (string.IsNullOrEmpty(token))
            {
                return Json(model, JsonRequestBehavior.DenyGet);
            }

            model.IsOk = await _appService.DeleteToken(token, User.Identity.GetId());

            return Json(model, JsonRequestBehavior.DenyGet);
        }
    }
}