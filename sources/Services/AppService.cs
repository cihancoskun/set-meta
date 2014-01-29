using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using SetMeta.Web.Helpers;
using SetMeta.Web.Models;
using SetMeta.Web.ViewModels;

namespace SetMeta.Web.Services
{
    public interface IAppService
    {
        Task<long?> CreateApp(AppViewModel model);

        Task<PagedList<App>> GetApps(int pageNumber);
        Task<PagedList<App>> GetByUserId(long userId, int pageNumber);
        Task<PagedList<App>> GetByUserId(string userPublicId, int pageNumber);

        Task<App> Get(long appId);
        Task<App> Get(string appPublicId);

        Task<bool> CreateToken(TokenViewModel token);
        Task<bool> DeleteToken(string token, long deletedBy);

        Task<bool> IsTokenValid(string token);

        Task<bool> ChangeStatus(long appId, bool isActive);
        Task<bool> ChangeStatus(string appPublicId, bool isActive);
    }

    public class AppService : BaseService, IAppService
    {
        public async Task<long?> CreateApp(AppViewModel model)
        {
            if (!model.IsValid()) return null;

            var user = _context.Set<User>().FirstOrDefault(x => x.Id == model.CreatedBy && x.IsActive);
            if (user == null) return null;

            var key = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var app = new App
            {
                UserEmail = model.Email,
                UserPublicId = user.PublicId,
                Name = model.Name,
                Url = model.Url,
                IsActive = true,
                CreatedBy = model.CreatedBy,
                Description = model.Description ?? string.Empty,
                Tokens = new List<Token>
                {
                    new Token
                    {
                        CreatedBy = model.CreatedBy,
                        Key = key,
                        PublicId = key,
                        UsageCount = 0,
                        IsAppActive = true
                    }
                }
            };

            _context.Set<App>().Add(app);

            if (_context.SaveChanges() < 0) return null;

            return await Task.FromResult(app.Id);
        }

        
        public Task<PagedList<App>> GetApps(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<App>().Where(x => !x.IsDeleted);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<App>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<PagedList<App>> GetByUserId(long userId, int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<App>().Where(x => x.CreatedBy == userId);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<App>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<PagedList<App>> GetByUserId(string userPublicId, int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<App>().Where(x => x.UserPublicId == userPublicId);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<App>(pageNumber, ConstHelper.PageSize, count, items));
        }


        public Task<App> Get(long appId)
        {
            if (appId < 1) return null;

            var app = _context.Set<App>().Include(x => x.Tokens).FirstOrDefault(x => x.Id == appId);
            return Task.FromResult(app);
        }

        public Task<App> Get(string appPublicId)
        {
            if (string.IsNullOrEmpty(appPublicId)) return null;

            var app = _context.Set<App>().Include(x => x.Tokens).FirstOrDefault(x => x.PublicId == appPublicId);
            return Task.FromResult(app);
        }


        public Task<bool> CreateToken(TokenViewModel model)
        {
            if (!model.IsValid()) return Task.FromResult(false);

            var app = _context.Set<App>().FirstOrDefault(x => x.PublicId == model.AppId);
            if (app != null) return Task.FromResult(false);

            var entity = new Token
            {
                CreatedBy = model.CreatedBy,
                AppId = app.Id,
                Key = model.Token,
                PublicId = model.Token,
                UsageCount = 0,
                IsAppActive = true
            };
            _context.Set<Token>().Add(entity);

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> DeleteToken(string token, long deletedBy)
        {
            if (string.IsNullOrEmpty(token)) return Task.FromResult(false);

            var item = _context.Set<Token>().FirstOrDefault(x => x.Key == token);
            if (item == null) return Task.FromResult(false);

            item.DeletedAt = DateTime.Now;
            item.DeletedBy = deletedBy;
            item.IsDeleted = true;

            return Task.FromResult(_context.SaveChanges() > 0);
        }


        public Task<bool> IsTokenValid(string token)
        {
            return Task.FromResult(_context.Set<Token>().Any(x => x.Key == token && x.IsActive && x.IsAppActive));
        }


        public Task<bool> ChangeStatus(long appId, bool isActive)
        {
            if (appId < 1) return Task.FromResult(false);

            var app = _context.Set<App>().Include(x => x.Tokens).FirstOrDefault(x => x.Id == appId);
            if (app == null) return Task.FromResult(false);

            foreach (var token in app.Tokens)
            {
                token.IsAppActive = !isActive;
                token.IsActive = !isActive;
            }

            app.IsActive = !isActive;

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> ChangeStatus(string appPublicId, bool isActive)
        {
            if (string.IsNullOrEmpty(appPublicId)) return Task.FromResult(false);

            var app = _context.Set<App>().Include(x => x.Tokens).FirstOrDefault(x => x.PublicId == appPublicId);
            if (app == null) return Task.FromResult(false);

            foreach (var token in app.Tokens)
            {
                token.IsAppActive = !isActive;
                token.IsActive = !isActive;
            }

            app.IsActive = !isActive;

            return Task.FromResult(_context.SaveChanges() > 0);
        }
    }
}