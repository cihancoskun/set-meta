using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SetMeta.Tests._Builders;
using SetMeta.Tests._TestHelpers;
using SetMeta.Web.Controllers;
using SetMeta.Web.Models;
using SetMeta.Web.Services;

namespace SetMeta.Tests.Behaviour
{
    [TestFixture]
    public class VisitorBehaviourTests
    {
        private const string ActionNameContact = "Contact";

        public void any_visitor_can_give_feedback()
        {
            
        }

        [Test]
        public async void any_visitor_can_send_contact_message()
        {
            //arrange
            var validModel = new ContactModel
            {
                Name = "name",
                Email = "test@test.com",
                Title = "title",
                Info = "info"
            };
            var feedbackService = new Mock<IFeedbackService>(); 
            feedbackService.Setup(x => x.CreateContactMessage(validModel.Name, validModel.Email, validModel.Title, validModel.Info))
                           .Returns(Task.FromResult(true));

            //act
            var sut = new HomeControllerBuilder().WithFeedbackService(feedbackService.Object)
                                                 .Build();
            var result = await sut.Contact(validModel);

            //assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<ViewResult>(result);

            feedbackService.Verify(x => x.CreateContactMessage(validModel.Name, validModel.Email, validModel.Title, validModel.Info), Times.Once);

            sut.AssertPostAttribute(ActionNameContact, new[] { typeof(ContactModel) });
            sut.AssertAllowAnonymousAttribute(ActionNameContact, new[] { typeof(ContactModel) }); 

        }

        public void any_visitor_can_search_meta_data() { }
    }
}