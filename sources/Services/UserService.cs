using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using SetMeta.Web.Helpers;
using SetMeta.Web.Data.Entities;
using SetMeta.Web.Models;

namespace SetMeta.Web.Services
{
    public class UserService : BaseService, IUserService
    {
        public Task<bool> Create(UserModel model, string roleName)
        {
            if (!model.IsValid()) return Task.FromResult(false);

            var img = GravatarHelper.GetGravatarURL(model.Email);
            var user = new User
            {
                PublicId = model.Id,
                Email = model.Email,
                Name = model.Name,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                ImageUrl = img,
                RoleId = ConstHelper.BasicRoles[roleName],
                RoleName = roleName,
                IsActive = true,
                Language = model.Language
            };
            _context.Set<User>().Add(user);

            if (roleName == ConstHelper.Developer)
            {
                var key = Guid.NewGuid().ToNoDashString();
                var app = new App
                {
                    UserEmail = model.Email,
                    Name = model.Name,
                    Url = "example.com",
                    IsActive = true,
                    Tokens = new List<Token>
                    {
                        new Token
                        {
                            Key = key,
                            PublicId = key,
                            UsageCount = 0,
                            IsAppActive = true,
                            IsActive = true
                        }
                    }
                };

                _context.Set<App>().Add(app);
            }

            return Task.FromResult(_context.SaveChanges() > 0);
        }


        public Task<PagedList<User>> GetUsers(int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<User>().Where(x => !x.IsDeleted);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<User>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<PagedList<User>> GetUsersByRoleId(int roleId, int pageNumber)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var query = _context.Set<User>().Where(x => !x.IsDeleted && x.RoleId == roleId);

            var count = query.Count();
            var items = query.OrderByDescending(x => x.Id).Skip(ConstHelper.PageSize * (pageNumber - 1)).Take(ConstHelper.PageSize).ToList();

            return Task.FromResult(new PagedList<User>(pageNumber, ConstHelper.PageSize, count, items));
        }

        public Task<User> Get(string userPublicId)
        {
            if (string.IsNullOrEmpty(userPublicId)) return null;

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == userPublicId);
            return Task.FromResult(user);
        }

        public Task<User> Get(long userId)
        {
            if (userId < 1) return null;

            var user = _context.Set<User>().FirstOrDefault(x => x.Id == userId);
            return Task.FromResult(user);
        }

        public Task<User> GetByEmail(string email)
        {
            if (!email.IsEmail()) return null;

            var user = _context.Set<User>().FirstOrDefault(x => x.Email == email);
            return Task.FromResult(user);
        }


        public Task<bool> Authenticate(string email, string password)
        {
            if (!email.IsEmail() || string.IsNullOrEmpty(password)) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.Email == email);
            if (user == null) return Task.FromResult(false);

            var result = false;

            if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)
                && user.LoginTryCount < 5)
            {
                user.LastLoginAt = DateTime.Now;
                user.LoginTryCount = 0;
                result = true;
            }
            else
            {
                user.LoginTryCount += 1;
            }

            _context.SaveChanges();

            return Task.FromResult(result);
        }


        public Task<bool> ChangeStatus(long userId, bool isActive)
        {
            if (userId < 1) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.Id == userId);
            if (user == null) return Task.FromResult(false);

            user.IsActive = false;

            var apps = _context.Set<App>().Include(x => x.Tokens).Where(x => x.UserPublicId == user.PublicId);
            foreach (var app in apps)
            {
                app.IsActive = !isActive;

                foreach (var token in app.Tokens)
                {
                    token.IsAppActive = !isActive;
                    token.IsActive = !isActive;
                }
            }

            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public Task<bool> ChangeStatus(string userPublicId, bool isActive)
        {
            if (string.IsNullOrEmpty(userPublicId)) return Task.FromResult(false);

            var user = _context.Set<User>().FirstOrDefault(x => x.PublicId == userPublicId);
            if (user == null) return Task.FromResult(false);

            user.IsActive = false;

            var apps = _context.Set<App>().Include(x => x.Tokens).Where(x => x.UserPublicId == user.PublicId);
            foreach (var app in apps)
            {
                app.IsActive = !isActive;

                foreach (var token in app.Tokens)
                {
                    token.IsAppActive = !isActive;
                    token.IsActive = !isActive;
                }
            }

            return Task.FromResult(_context.SaveChanges() > 0);
        }
    }

    public interface IUserService
    {
        Task<bool> Create(UserModel model, string roleName);

        Task<PagedList<User>> GetUsers(int pageNumber);
        Task<PagedList<User>> GetUsersByRoleId(int roleId, int pageNumber);

        Task<User> Get(string userPublicId);
        Task<User> Get(long userId);
        Task<User> GetByEmail(string email);

        Task<bool> Authenticate(string email, string password);

        Task<bool> ChangeStatus(long userId, bool isActive);
        Task<bool> ChangeStatus(string userPublicId, bool isActive);

       

    }
}