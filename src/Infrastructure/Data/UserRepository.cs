using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;


namespace FAIS.Infrastructure.Data
{
    public class UserRepository : EFRepository<User, decimal>, IUserRepository
    {
        public UserRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<User> Get()
        {
            return _dbContext.Users;
        }

        public User GetById(decimal id)
        {
            return _dbContext.Users.Where(t => t.Id == id).ToList()[0];
        }

        public User GetByUserName(string userName)
        {
            return _dbContext.Users.Where(t => t.UserName == userName).ToList()[0];
        }

        public List<PermissionModel> GetPermissions(int id)
        {
            List<int> roleIds = _dbContext.UserRoles.Where(t => t.UserId == id).Select(s => s.RoleId).ToList();
            var rolePermissions = _dbContext.RolePermissions.Where(t => roleIds.Contains(t.RoleId)).ToList();

            List<PermissionModel> permissions = new List<PermissionModel>();

            foreach (var permission in rolePermissions)
            {
                var module = _dbContext.Modules.Where(t => t.Id == permission.ModuleId).ToList()[0];

                permissions.Add(new PermissionModel()
                {
                    Id = permission.Id,
                    RoleId = permission.RoleId,
                    ModuleId = module.Id,
                    ModuleName = module.Name,
                    Url = module.Url,
                    Icon = module.Icon,
                    GroupName = module.GroupName,
                    IsCreate = permission.IsCreate == 'Y',
                    IsRead = permission.IsRead == 'Y',
                    IsUpdate = permission.IsUpdate == 'Y'
                });
            }

            return permissions;
        }

        public async Task<User> LockedAccount(User user)
        {
            return await UpdateAsync(user);
        }

        public async Task<User> UpdateSignInAttempts(User user)
        {
            return await UpdateAsync(user);
        }

        public async Task<User> Add(User user)
        {
            return await AddAsync(user);
        }

     
    }
}
