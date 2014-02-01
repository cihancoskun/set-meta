using System.Threading.Tasks;
using System.Web.Mvc;

using Moq;
using NUnit.Framework;

using SetMeta.Tests._Builders;
using SetMeta.Tests._TestHelpers;
using SetMeta.Web.Helpers;
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
        const string ActionNameChangeStatus = "ChangeStatus";

        [Test]
        public async void developer_or_admin_can_create_app()
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
                                                .BuildWithMockControllerContext("1","name","test@test.com",ConstHelper.Developer);

            var result = await sut.New(validModel);

            //assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<RedirectResult>(result);

            appService.Verify(x => x.CreateApp(validModel), Times.Once);

            sut.AssertPostAttribute(ActionNameNew, new[] { typeof(AppModel) });
        }

        [Test]
        public async void developer_or_admin_can_deactivate_app()
        {
            //arrange 
            var appService = new Mock<IAppService>();
            appService.Setup(x => x.ChangeStatus("1","1",true)).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .Build();

            var result = await sut.ChangeStatus("1",true);

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsAssignableFrom<JsonResult>(result);
            Assert.IsAssignableFrom<ResponseModel>(result.Data);

            appService.Verify(x => x.ChangeStatus("1", "1", true), Times.Once);

            sut.AssertPostAttribute(ActionNameChangeStatus, new[] { typeof(string), typeof(bool) });
        }

        [Test]
        public async void developer_or_admin_can_activate_app()
        {
            //arrange 
            var appService = new Mock<IAppService>();
            appService.Setup(x => x.ChangeStatus("1", "1", false)).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .BuildWithMockControllerContext("1","name","test@test.com",ConstHelper.User); 

            var result = await sut.ChangeStatus("1", false);

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsAssignableFrom<JsonResult>(result);
            Assert.IsAssignableFrom<ResponseModel>(result.Data);

            appService.Verify(x => x.ChangeStatus("1", "1", false), Times.Once);

            sut.AssertPostAttribute(ActionNameChangeStatus, new[] { typeof(string), typeof(bool) });
        }

        [Test]
        public async void developer_or_admin_can_create_token()
        {
            //arrange   
            var appService = new Mock<IAppService>();

            appService.Setup(x => x.CreateToken(It.IsAny<TokenModel>())).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .BuildWithMockControllerContext("1", "name", "test@test.com", ConstHelper.Developer);

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
        public async void developer_or_admin_can_delete_token()
        {
            //arrange   
            var appService = new Mock<IAppService>();

            appService.Setup(x => x.DeleteToken(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            //act
            var sut = new AppControllerBuilder().WithAppService(appService.Object)
                                                .BuildWithMockControllerContext("1", "name", "test@test.com", ConstHelper.Developer);

            var result = await sut.DeleteToken("1");

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsAssignableFrom<JsonResult>(result);
            Assert.IsAssignableFrom<ResponseModel>(result.Data);

            appService.Verify(x => x.DeleteToken(It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            sut.AssertPostAttribute(ActionNameDeleteToken, new[] { typeof(string) });
        }
          
        public void developer_or_admin_in_developer_role_can_add_meta_data() { }
        public void developer_or_admin_in_developer_role_can_edit_meta_data() { } 
        public void developer_or_admin_in_admin_role_can_add_meta_data() { }
        public void developer_or_admin_in_admin_role_can_edit_meta_data() { }
        public void developer_or_admin_in_admin_role_can_delete_meta_data() { } 
        public void developer_or_admin_in_developer_role_can_NOT_delete_meta_data() { }

    }
}