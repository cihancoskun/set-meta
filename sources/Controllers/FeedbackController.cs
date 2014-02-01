using System.Threading.Tasks;
using System.Web.Mvc;

using SetMeta.Web.Helpers;
using SetMeta.Web.Services;
using SetMeta.Web.Models;

namespace SetMeta.Web.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<JsonResult> New(string email, string info)
        {
            var model = new ResponseModel { IsOk = false };
            SetPleaseTryAgain(model);
            if (string.IsNullOrEmpty(info)) return Json(model, JsonRequestBehavior.AllowGet);

            if (User.Identity.IsAuthenticated)
            {
                email = User.Identity.GetEmail();
            }

            model.IsOk = await _feedbackService.CreateFeedback(info, email);

            if (model.IsOk)
            {
                model.Msg = _htmlHelper.LocalizationString("data_saved_successfully_msg");
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> ChangeStatus(string id, bool isActive)
        {
            var model = new ResponseModel { IsOk = false };
            if (string.IsNullOrEmpty(id))
            {
                return Json(model, JsonRequestBehavior.DenyGet);
            }

            model.IsOk = await _feedbackService.ChangeStatus(id, isActive);
            return Json(model, JsonRequestBehavior.DenyGet);
        }
    }
}