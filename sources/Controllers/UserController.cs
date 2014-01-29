using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using SetMeta.Web.Helpers;
using SetMeta.Web.Services;
using SetMeta.Web.ViewModels;

namespace SetMeta.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IFormsAuthenticationService _formsAuthenticationService;
        private readonly IUserService _userService;

        public UserController(
            IFormsAuthenticationService formsAuthenticationService,
            IUserService userService)
        {
            _formsAuthenticationService = formsAuthenticationService;
            _userService = userService;
        }

        #region Membership
        [HttpGet, AllowAnonymous]
        public ActionResult New()
        {
            var model = new UserViewModel();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult> New(UserViewModel model)
        {
            if (!model.IsValid())
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            model.Language = Thread.CurrentThread.CurrentUICulture.Name;
            model.Id = Guid.NewGuid().ToNoDashString();

            var isCreated = await _userService.Create(model, ConstHelper.Developer);
            if (isCreated)
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            _formsAuthenticationService.SignIn(model.Id, model.Name, model.Email, ConstHelper.Developer, true);

            return Redirect("/user/apps");
        }

        [HttpGet, AllowAnonymous]
        public ActionResult PasswordReset()
        {
            var model = new PasswordResetViewModel();
            if (User.Identity.IsAuthenticated)
            {
                model.Email = User.Identity.GetEmail();
            }

            return View(model);
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!model.IsValid())
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            var authenticated = await _userService.Authenticate(model.Email, model.Password);
            if (!authenticated)
            {
                SetPleaseTryAgain(model);
                return View(model);
            }

            var user = await _userService.GetByEmail(model.Email);
            _formsAuthenticationService.SignIn(user.PublicId, user.Name, user.Email, user.RoleName, true);

            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return Redirect("/user/apps");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _formsAuthenticationService.SignOut();
            return RedirectToHome();
        }
        #endregion
    }
}