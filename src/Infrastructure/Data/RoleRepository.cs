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
    public class RoleRepository : EFRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<RoleModel> Get()
        {
            var roles = (from rol in _dbContext.Roles.AsNoTracking()
                        join usrC in _dbContext.Users.AsNoTracking() on rol.CreatedBy equals usrC.Id
                        join usrU in _dbContext.Users.AsNoTracking() on rol.UpdatedBy equals usrU.Id into usrUX
                        from usrU in usrUX.DefaultIfEmpty()
                        orderby rol.Id descending
                        select new RoleModel()
                        {
                            Id = rol.Id,
                            Name = rol.Name,
                            Description = rol.Description,
                            IsActive = rol.IsActive,
                            StatusDate = rol.StatusDate,
                            CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                            CreatedAt = rol.CreatedAt,
                            UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                            UpdatedAt = rol.UpdatedBy != null ? rol.UpdatedAt : null,
                        }).ToList();

            return roles;
        }

        public Role GetById(int id)
        {
            return _dbContext.Roles.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Role> Add(Role role)
        {
            return await AddAsync(role);
        }

        public async Task<Role> Update(Role role)
        {
            return await UpdateAsync(role);
        }

        public IReadOnlyCollection<Role> GetUserRolesById(int id)
        {
            IReadOnlyCollection<int> UserRolesId = _dbContext.UserRoles.AsNoTracking().Where(u => u.UserId == id).Select(s => s.RoleId).ToList();
            var UserRoles = _dbContext.Roles.Where(r => UserRolesId.Contains(r.Id))
                .Select(r => new Role
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CreatedAt = r.CreatedAt
                })
                .ToList();

            return UserRoles;
        }
        public Role GetRoleIdByName(string rolename)
        {
            return _dbContext.Roles.FirstOrDefault(r => r.Name == rolename);
        }
    }
}
