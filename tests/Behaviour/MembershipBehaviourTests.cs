using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;

using SetMeta.Tests._TestHelpers;
using SetMeta.Tests._Builders;
using SetMeta.Web.Helpers;
using SetMeta.Web.Services;
using SetMeta.Web.ViewModels; 

namespace SetMeta.Tests.Behaviour
{
    [TestFixture]
    public class MembershipBehaviourTests
    {
        const string ActionNameNew = "New";
        const string ActionNameLogin = "Login";
        const string ActionNameReset = "PasswordReset";

        [Test]
        public async void any_visitor_can_create_developer_account()
        {
            //arrange
            var validModel = new UserViewModel
            {
                Name = "model",
                Password = "pass",
                Email = "test@test.com",
                Language = Thread.CurrentThread.CurrentUICulture.Name,
                Id = Guid.NewGuid().ToNoDashString()
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.Create(validModel, ConstHelper.Developer))
                       .Returns(Task.FromResult(true));

            var formAuthenticationService = new Mock<IFormsAuthenticationService>();
            formAuthenticationService.Setup(x => x.SignIn(validModel.Id, validModel.Name, validModel.Email, ConstHelper.Developer, true));

            //act
            var sut = new UserControllerBuilder().WithUserService(userService.Object)
                                                 .WithFormsAuthenticationService(formAuthenticationService.Object)
                                                 .Build();

            var result = await sut.New(validModel);

            //assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<RedirectResult>(result);  

            userService.Verify(x => x.Create(validModel, ConstHelper.Developer), Times.Once);
            formAuthenticationService.Verify(x => x.SignIn(validModel.Id, validModel.Name, validModel.Email, ConstHelper.Developer, true), Times.Once);

            sut.AssertPostAttribute(ActionNameNew, new[] { typeof(UserViewModel) });
            sut.AssertAllowAnonymousAttribute(ActionNameNew, new[] { typeof(UserViewModel) }); 
        }

        [Test]
        public void any_user_can_login()
        {
            //arrange

            //act
            var sut = new UserControllerBuilder().Build();
            var result = sut.Login() as ViewResult;

            //assert 
            Assert.NotNull(result); 
            Assert.NotNull(result.Model);
            Assert.IsAssignableFrom<LoginViewModel>(result.Model);
            Assert.IsInstanceOf<BaseViewModel>(result.Model);

            sut.AssertGetAttribute(ActionNameLogin);
            sut.AssertAllowAnonymousAttribute(ActionNameLogin);
        }

        [Test]
        public void any_user_can_request_password_reset_link()
        {
            //arrange

            //act

            //assert
        }

        public void any_user_can_change_password()
        {
            //arrange

            //act

            //assert
        }
    }
}