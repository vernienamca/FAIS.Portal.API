using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Enumeration;
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

        public IReadOnlyCollection<UserRoleModel> Get()
        {
            var roles = (from ur in _dbContext.UserRoles.AsNoTracking()
                         join rol in _dbContext.Roles.AsNoTracking() on ur.RoleId equals rol.Id into rolX
                         from rol in rolX.DefaultIfEmpty()
                         join usrN in _dbContext.Users.AsNoTracking() on ur.UserId equals usrN.Id into usrNX
                         from usrN in usrNX.DefaultIfEmpty()
                         join usrC in _dbContext.Users.AsNoTracking() on ur.CreatedBy equals usrC.Id
                         join usrU in _dbContext.Users.AsNoTracking() on ur.UpdatedBy equals usrU.Id into usrUX
                         from usrU in usrUX.DefaultIfEmpty()

                         orderby ur.UserId descending
                         select new UserRoleModel()
                         {
                             Id = ur.UserId,
                             Name = usrN.LastName + usrN.FirstName,
                             Roles = new List<string> { rol.Description },
                             IsActive = ur.IsActive == 'Y',
                             StatusDate = ur.IsActive == 'Y' ? ur.StatusDate.ToString() : string.Empty,
                             CreatedAt = ur.CreatedAt,
                             UpdatedAt = ur.UpdatedAt,
                             Email = usrN.EmailAddress

                         }).ToList();


            return roles;
        }

        public IReadOnlyCollection<UserRoleModel> GetUserRolesById(int id)
        {
            List<UserRoleModel> userRoles = new List<UserRoleModel>();

            //var userRoles = _dbContext.UserRoles.AsNoTracking()
            //    .Where(u => u.UserId == id)
            //    .Join(
            //        _dbContext.Roles.AsNoTracking(),
            //        userRole => userRole.RoleId,
            //        role => role.Id,
            //        (userRole, role) => new UserRoleModel
            //        {
            //            Id = userRole.Id,
            //            UserId = userRole.UserId,
            //            RoleId = userRole.RoleId,                                                                                                                                                                                                               
            //            IsActive = userRole.IsActive,

            //            Name = role.Name,                                                     
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
      
        public IReadOnlyCollection<string> GetUserEmailsByRole(int roleId)
        {
             IReadOnlyCollection<string> emailAddresses = (from ur in _dbContext.UserRoles.AsNoTracking()
                                                           join usrN in _dbContext.Users.AsNoTracking() on ur.UserId equals usrN.Id
                                                           where ur.RoleId == roleId
                                                           join ro in _dbContext.Roles.AsNoTracking() on ur.RoleId equals ro.Id
                                                           select usrN.EmailAddress)
                                                          .ToList();

            return emailAddresses;
        }

    }
}
