using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SetMeta.Web.Helpers;
using SetMeta.Web.Data.Entities;
using SetMeta.Web.Models;

namespace SetMeta.Web.Services
{
    public class AppService : BaseService, IAppService
    {
        public Task<bool> CreateApp(AppModel model)
        {
            if (!model.IsValid()) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == model.CreatedBy && x.IsActive);
            if (user == null) Task.FromResult(false);

            if (user.RoleName == ConstHelper.User) Task.FromResult(false);

            var key = Guid.NewGuid().ToNoDashString();
            var app = new App
            {
                PublicId = model.Id,
                UserEmail = model.Email,
                UserPublicId = user.PublicId,
                Name = model.Name,
                Url = model.Url,
                IsActive = true,
                CreatedBy = user.Id,
                Description = model.Description ?? string.Empty,
                Tokens = new List<Token>
                {
                    new Token
                    {
                        CreatedBy = user.Id,
                        Key = key,
                        PublicId = key,
                        UsageCount = 0,
                        IsAppActive = true,
                        IsActive = true
                    }
                }
            };

            _context.Set<App>().Add(app);

            return Task.FromResult(_context.SaveChanges() > 0);
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

        public Task<bool> CreateToken(TokenModel model)
        {
            if (!model.IsValid()) return Task.FromResult(false);

            var app = _context.Set<App>().FirstOrDefault(x => x.PublicId == model.AppId && x.UserPublicId == model.CreatedBy);
            if (app == null) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == model.CreatedBy);
            if (user == null) return Task.FromResult(false);

            if (user.RoleName == ConstHelper.User) return Task.FromResult(false);

            var entity = new Token
            {
                CreatedBy = user.Id,
                AppId = app.Id,
                Key = model.Token,
                PublicId = model.Token,
                UsageCount = 0,
                IsAppActive = true,
                IsActive = true
            };
            _context.Set<Token>().Add(entity);

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> DeleteToken(string token, string deletedBy)
        {
            if (string.IsNullOrEmpty(token)) return Task.FromResult(false);

            var item = _context.Set<Token>().FirstOrDefault(x => x.Key == token);
            if (item == null) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == deletedBy);
            if (user == null) return Task.FromResult(false);

            if (user.RoleName == ConstHelper.User) return Task.FromResult(false);

            if (user.Id != item.CreatedBy
                && user.RoleName != ConstHelper.Admin) Task.FromResult(false);

            item.DeletedAt = DateTime.Now;
            item.DeletedBy = user.Id;
            item.IsDeleted = true;

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> IsTokenValid(string token)
        {
            return Task.FromResult(_context.Set<Token>().Any(x => x.Key == token
                                                                  && x.IsActive
                                                                  && x.IsAppActive
                                                                  && !x.IsDeleted));
        }

        public Task<bool> ChangeStatus(long appId, string updatedBy, bool isActive)
        {
            if (appId < 1) return Task.FromResult(false);

            var app = _context.Set<App>().FirstOrDefault(x => x.Id == appId);
            if (app == null) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == updatedBy);
            if (user == null) return Task.FromResult(false);
            if (app.UserPublicId != updatedBy && user.RoleName != ConstHelper.Admin) return Task.FromResult(false);

            var tokens = _context.Set<Token>().Where(x => x.AppId == app.Id);
            foreach (var token in tokens)
            {
                token.IsAppActive = !isActive;
                token.IsActive = !isActive;
            }

            app.IsActive = !isActive;

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> ChangeStatus(string appPublicId, string updatedBy, bool isActive)
        {
            if (string.IsNullOrEmpty(appPublicId)) return Task.FromResult(false);

            var app = _context.Set<App>().FirstOrDefault(x => x.PublicId == appPublicId);
            if (app == null) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == updatedBy);
            if (user == null) return Task.FromResult(false);
            if (app.UserPublicId != updatedBy && user.RoleName != ConstHelper.Admin) return Task.FromResult(false);

            var tokens = _context.Set<Token>().Where(x => x.AppId == app.Id);
            foreach (var token in tokens)
            {
                token.IsAppActive = !isActive;
                token.IsActive = !isActive;
            }

            app.IsActive = !isActive;

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> LogRequest(string token, string ip, string url)
        {
            if (string.IsNullOrEmpty(token)
                && string.IsNullOrEmpty(url)) return Task.FromResult(false);

            var tokenEntity = _context.Set<Token>().FirstOrDefault(x => x.Key == token);
            if (tokenEntity == null) return Task.FromResult(false);

            tokenEntity.UsageCount = tokenEntity.UsageCount + 1;

            var log = new RequestLog
            {
                Token = token,
                IP = ip,
                Url = url
            };
            _context.Set<RequestLog>().Add(log);

            return Task.FromResult(_context.SaveChanges() > 0);
        }
    }

    public interface IAppService
    {
        Task<bool> CreateApp(AppModel model);

        Task<PagedList<App>> GetApps(int pageNumber);
        Task<PagedList<App>> GetByUserId(long userId, int pageNumber);
        Task<PagedList<App>> GetByUserId(string userPublicId, int pageNumber);

        Task<App> Get(long appId);
        Task<App> Get(string appPublicId);

        Task<bool> CreateToken(TokenModel token);
        Task<bool> DeleteToken(string token, string deletedBy);

        Task<bool> IsTokenValid(string token);

        Task<bool> ChangeStatus(long appId, string updatedBy, bool isActive);
        Task<bool> ChangeStatus(string appPublicId, string updatedBy, bool isActive);

        /// <summary>
        /// logs the api requests
        /// </summary>
        /// <param name="token">the request token passed in http header</param>
        /// <param name="ip">the ip of the request</param>
        /// <param name="url">the url of the request</param>
        /// <returns></returns>
        Task<bool> LogRequest(string token, string ip, string url);
    }
}