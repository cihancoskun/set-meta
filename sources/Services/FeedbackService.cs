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
        public Task<PagedList<Feedback>> GetFeedbacks(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<Feedback>().Where(x => !x.IsDeleted);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<Feedback>(pageNumber, ConstHelper.PageSize, count, items));
        }
    }

    public interface IFeedbackService
    {
        Task<bool> CreateFeedback(string info, string email);
        Task<PagedList<Feedback>> GetFeedbacks(int pageNumber);
    }
}