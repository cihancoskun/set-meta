using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Moq;
using SetMeta.Web.Controllers;
using SetMeta.Web.Services;

namespace SetMeta.Tests._Builders
{
    public class AppControllerBuilder
    { 
        private IAppService _appService;

        public AppControllerBuilder()
        { 
            _appService = null;
        }
          
        internal AppControllerBuilder WithAppService(IAppService appService)
        {
            _appService = appService;
            return this;
        }

        internal AppController BuildWithMockControllerContext(string id, string name, string email, string role)
        {
            var sut = Build();

            var controllerContext = new Mock<ControllerContext>();
            var httpContext = new Mock<HttpContextBase>();
            var httpRequest = new Mock<HttpRequestBase>();
            var httpResponse = new Mock<HttpResponseBase>();
            var user = new Mock<IPrincipal>();
            var currentUser = new Mock<IIdentity>();

            controllerContext.Setup(x => x.HttpContext).Returns(httpContext.Object);
            httpContext.Setup(x => x.Request).Returns(httpRequest.Object);
            httpContext.Setup(x => x.Response).Returns(httpResponse.Object);
            httpContext.Setup(x => x.User).Returns(user.Object);
            user.Setup(x => x.Identity).Returns(currentUser.Object);
            currentUser.Setup(x => x.IsAuthenticated).Returns(true);
            currentUser.Setup(x => x.Name).Returns(string.Format("{0}|{1}|{2}|{3}", id, name, email, role));

            httpResponse.Setup(x => x.SetCookie(It.IsAny<HttpCookie>()));

            sut.ControllerContext = controllerContext.Object;
            return sut;
        }

        internal AppController Build()
        {
            return new AppController(_appService);
        }
    }
}