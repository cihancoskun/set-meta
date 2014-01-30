using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;

using SetMeta.Tests._TestHelpers;
using SetMeta.Tests._Builders;
using SetMeta.Web.Helpers;
using SetMeta.Web.Models;
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
                Name = "name",
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
        public async void any_user_can_login()
        {
            //arrange
            var validModel = new LoginViewModel
            { 
                Password = "pass",
                Email = "test@test.com" 
            };

            var user = new User
            {
                PublicId = "publicId", 
                Name="name",
                Email = "test@test.com",
                RoleName = ConstHelper.Developer
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.Authenticate(validModel.Email,validModel.Password))
                       .Returns(Task.FromResult(true));

            userService.Setup(x => x.GetByEmail(validModel.Email))
                       .Returns(Task.FromResult(user));

            var formAuthenticationService = new Mock<IFormsAuthenticationService>();
            formAuthenticationService.Setup(x => x.SignIn(user.PublicId, user.Name, user.Email, ConstHelper.Developer, true));

            //act
            var sut = new UserControllerBuilder().WithUserService(userService.Object)
                                                 .WithFormsAuthenticationService(formAuthenticationService.Object)
                                                 .Build();

            var result = await sut.Login(validModel);

            //assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<RedirectResult>(result);

            userService.Verify(x => x.Authenticate(validModel.Email, validModel.Password), Times.Once);
            userService.Verify(x => x.GetByEmail(validModel.Email), Times.Once);
            formAuthenticationService.Verify(x => x.SignIn(user.PublicId, user.Name, user.Email, ConstHelper.Developer, true), Times.Once);

            sut.AssertPostAttribute(ActionNameNew, new[] { typeof(UserViewModel) });
            sut.AssertAllowAnonymousAttribute(ActionNameNew, new[] { typeof(UserViewModel) }); 
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