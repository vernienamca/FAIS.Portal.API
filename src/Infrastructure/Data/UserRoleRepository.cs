using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class UserRoleRepository : EFRepository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<UserRole> Get()
        {
            var roles = (from rol in _dbContext.UserRoles.AsNoTracking()
                         join usrC in _dbContext.Users.AsNoTracking() on rol.CreatedBy equals usrC.Id
                         join usrU in _dbContext.Users.AsNoTracking() on rol.UpdatedBy equals usrU.Id into usrUX
                         from usrU in usrUX.DefaultIfEmpty()
                         orderby rol.Id descending
                         select new UserRole()
                         {
                             Id = rol.Id,
                             UserId = rol.UserId,
                             RoleId = rol.RoleId,
                             IsActive = rol.IsActive,
                             StatusDate = rol.StatusDate,
                             CreatedAt = rol.CreatedAt,
                             UpdatedAt = rol.UpdatedAt,
                      
                         }).ToList();

            return roles;
        }

        public IReadOnlyCollection<UserRoleModel> GetUserRolesById(int id)
        {
            var userRoles = _dbContext.UserRoles.AsNoTracking()
                .Where(u => u.UserId == id)
                .Join(
                    _dbContext.Roles.AsNoTracking(),
                    userRole => userRole.RoleId,
                    role => role.Id,
                    (userRole, role) => new UserRoleModel
                    {
                        Id = userRole.Id,
                        UserId = userRole.UserId,
                        RoleId = userRole.RoleId,
                        IsActive = userRole.IsActive,
                       
                        Name = role.Name, 
                    })
                .ToList();

            return userRoles;
        }


        public async Task<UserRole> Add(UserRole userRole)
        {
            return await AddAsync(userRole);
        }

        public async Task<UserRole> Update(UserRole userRole)
        {
            return await UpdateAsync(userRole);
        }
    }
}
