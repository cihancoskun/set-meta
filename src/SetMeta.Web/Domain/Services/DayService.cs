using System;
using System.Linq;
using System.Threading.Tasks;
using SetMeta.Web.Helpers;
using SetMeta.Web.Models;
using SetMeta.Web.Domain.Entities;
using SetMeta.Web.Domain.Repositories;

namespace SetMeta.Web.Domain.Services
{
    public interface IDayService
    {
        Task<bool> CreateDay(DayModel day);
        Task<Day> GetDayById(long id);
        Task<Day> GetDayById(string  publicId);
        Task<Day> GetDayByCode(string code);
        Task<PagedList<Day>> GetDays(int pageNumber);
    }

    public class DayService : IDayService
    {
        private readonly IRepository<Day> _dayRepository;

        public DayService(IRepository<Day> dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public Task<bool> CreateDay(DayModel model)
        {
            if (!model.IsValidForNew())
                return null;

            var day = new Day
            {
                Code = model.Code,
                Value = model.Value,
                Description = model.Description
            };

            _dayRepository.Create(day);

            var result = _dayRepository.SaveChanges();
            return Task.FromResult(result);
        }

        public Task<Day> GetDayById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Day> GetDayById(string publicid)
        {
            throw new System.NotImplementedException();
        }

        public Task<Day> GetDayByCode(string code)
        {
            var day = _dayRepository.FindOne(x => x.Code == code);
            return Task.FromResult(day);
        }

        public Task<PagedList<Day>> GetDays(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            pageNumber--;

            var items = _dayRepository.FindAll();

            long totalCount = items.Count();
            var totalPageCount = (int)Math.Ceiling(totalCount / (double)ConstHelper.PageSize);

            if (pageNumber > totalPageCount)
            {
                pageNumber = 1;
            }

            items = items.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber)).Take(ConstHelper.PageSize);

            return Task.FromResult(new PagedList<Day>(pageNumber, ConstHelper.PageSize, totalCount, items.ToList()));
        }
    }
}
