using System.Linq;
using System.Threading.Tasks;
using SetMeta.Web.Helpers;
using SetMeta.Web.Models;

namespace SetMeta.Web.Services
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        public Task<bool> CreateFeedback(string info, string email)
        {
            if (string.IsNullOrEmpty(info)) return Task.FromResult(false);

            if (string.IsNullOrWhiteSpace(email))
            {
                email = ConstHelper.Anonymous;
            }

            var feedback = new Feedback
            {
                Info = info,
                Email = email
            };

            var user = _context.Set<User>().FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                feedback.IsAnonymous = true;
                feedback.CreatedBy = user.Id;
            }

            _context.Set<Feedback>().Add(feedback);

            return Task.FromResult(_context.SaveChanges() > 0);
        }
    }

    public interface IFeedbackService
    {
        Task<bool> CreateFeedback(string info, string email);
    }
}