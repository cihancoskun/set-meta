using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SetMeta.Tests._Builders;
using SetMeta.Tests._TestHelpers;
using SetMeta.Web.Models;
using SetMeta.Web.Services;

namespace SetMeta.Tests.Behaviour
{
    [TestFixture]
    public class UserBehaviourTests
    {
        const string ActionNameNew = "New";
        const string ActionNameNewToken = "NewToken";
        const string ActionNameDeleteToken = "DeleteToken";

        [Test]
        public async void any_user_in_developer_role_can_create_app()
        {
            //arrange
            var validModel = new AppModel
            {
                Name = "name",
                Url = "url"
            };

            var appService = new Mock<IAppService>();
            appService.Setup(x => x.CreateApp(validModel)).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .BuildWithMockControllerContext();

            var result = await sut.New(validModel);

            //assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<RedirectResult>(result);

            appService.Verify(x => x.CreateApp(validModel), Times.Once);

            sut.AssertPostAttribute(ActionNameNew, new[] { typeof(AppModel) });
        }

        [Test]
        public void any_user_in_developer_role_can_deactivate_app()
        {
            //arrange 

            //act 

            //assert 
        }

        [Test]
        public void any_user_in_developer_role_can_activate_app()
        {
            //arrange 

            //act 

            //assert 
        }

        [Test]
        public async void any_user_in_developer_role_can_create_token()
        {
            //arrange   
            var appService = new Mock<IAppService>();

            appService.Setup(x => x.CreateToken(It.IsAny<TokenModel>())).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .BuildWithMockControllerContext();

            var result = await sut.NewToken("1");

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsAssignableFrom<JsonResult>(result);
            Assert.IsAssignableFrom<ResponseModel>(result.Data);

            appService.Verify(x => x.CreateToken(It.IsAny<TokenModel>()), Times.Once);

            sut.AssertPostAttribute(ActionNameNewToken, new[] { typeof(string) });
        }

        [Test]
        public async void any_user_in_developer_role_can_delete_token()
        {
            //arrange   
            var appService = new Mock<IAppService>();

            appService.Setup(x => x.DeleteToken(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .BuildWithMockControllerContext();

            var result = await sut.DeleteToken("1");

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsAssignableFrom<JsonResult>(result);
            Assert.IsAssignableFrom<ResponseModel>(result.Data);

            appService.Verify(x => x.DeleteToken(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            sut.AssertPostAttribute(ActionNameDeleteToken, new[] { typeof(string) });
        }

        public void any_user_in_admin_role_can_create_app() { }
        public void any_user_in_admin_role_can_deactivate_app() { }
        public void any_user_in_admin_role_can_activate_app() { }

        public void any_user_in_admin_role_can_create_token() { }
        public void any_user_in_admin_role_can_delete_token() { }

        public void any_user_in_developer_role_can_add_meta_data() { }
        public void any_user_in_developer_role_can_edit_meta_data() { }

        public void any_user_in_admin_role_can_add_meta_data() { }
        public void any_user_in_admin_role_can_edit_meta_data() { }
        public void any_user_in_admin_role_can_delete_meta_data() { }

        public void any_user_in_developer_role_can_NOT_delete_meta_data() { }
        public void any_user_in_user_role_can_NOT_delete_meta_data() { }
        public void any_user_in_user_role_can_NOT_add_meta_data() { }
        public void any_user_in_user_role_can_NOT_create_app() { }
        public void any_user_in_user_role_can_NOT_create_token() { }
    }
}