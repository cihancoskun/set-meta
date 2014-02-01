using SetMeta.Web.Controllers;
using SetMeta.Web.Services;

namespace SetMeta.Tests._Builders
{
    public class HomeControllerBuilder
    {
        private IFeedbackService _feedbackService;
        private IFormsAuthenticationService _formsAuthenticationService;

        public HomeControllerBuilder()
        {
            _feedbackService = null;
            _formsAuthenticationService = null; 
        }

        internal HomeControllerBuilder WithFormsAuthenticationService(IFormsAuthenticationService formsAuthenticationService)
        {
            _formsAuthenticationService = formsAuthenticationService;
            return this;
        }

        internal HomeControllerBuilder WithFeedbackService(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
            return this;
        } 

        internal HomeController Build()
        {
            return new HomeController(_formsAuthenticationService, _feedbackService);
        }
    
    }
}