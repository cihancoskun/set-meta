using System.Threading.Tasks;
using System.Web.Mvc;

using SetMeta.Web.Services;

namespace SetMeta.Web.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public Task<JsonResult> New(string email, string info)
        {
            if (string.IsNullOrEmpty(info)) return null;


            return null;
        }
    }
}