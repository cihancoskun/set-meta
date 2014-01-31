using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SetMeta.Web.Models;
using SetMeta.Web.Services;
using SetMeta.Web.ViewModels;

namespace SetMeta.Tests.Behaviour
{
    [TestFixture]
    public class UserBehaviourTests
    {
        public void any_user_in_developer_role_can_create_app()
        {
            var validModel = new AppViewModel {Name = "name", Url = "url"};
            var appService = new Mock<IAppService>();

            appService.Setup(x => x.CreateApp(validModel)).Returns(Task.FromResult(true));

        }
        public void any_user_in_developer_role_can_deactivate_app() { }
        public void any_user_in_developer_role_can_activate_app() { }

        public void any_user_in_developer_role_can_create_token() { }
        public void any_user_in_developer_role_can_delete_token() { }

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