using SetMeta.Web.Models;
using SetMeta.Web.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using SetMeta.Web.Helpers;

namespace SetMeta.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IFormsAuthenticationService _formsAuthenticationService;
        private readonly IFeedbackService _feedbackService;

        public HomeController(
             IFormsAuthenticationService formsAuthenticationService,
             IFeedbackService feedbackService)
        {
            _formsAuthenticationService = formsAuthenticationService;
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public ViewResult Contact()
        {
            var model = new ContactModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult> Contact(ContactModel model)
        {
            if (!model.IsValid())
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            model.IsSend = await _feedbackService.CreateContactMessage(model.Name, model.Email, model.Title, model.Info);

            if (model.IsSend)
            {
                model.Msg = _htmlHelper.LocalizationString("data_sent_successfully_msg");
            }
            else
            {
                model.Msg = _htmlHelper.LocalizationString("error_occured_while_sending_data_msg");
            }

            return View(model);
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