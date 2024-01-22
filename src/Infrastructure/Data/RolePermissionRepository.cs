using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class RolePermissionRepository : EFRepository<RolePermission, int>, IRolePermissionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionRepository"/> class.
        /// </summary>
        public RolePermissionRepository(FAISContext context) : base(context)
        {
        }

        public RolePermission GetById(int id)
        {
            return _dbContext.RolePermissions.Where(t => t.Id == id).ToList()[0];
        }

        public List<RolePermission> GetListById(int id)
        {
            return _dbContext.RolePermissions.Where(t => t.Id == id).ToList();
        }
        public async Task<RolePermission> UpdateRolePermission(RolePermission rolePermission)
        {
            return await UpdateAsync(rolePermission);
        }

        public List<RolePermission> GetRolePermissionByRoleId(int roleId)
        {
            var rolePermissionsQuery = _dbContext.RolePermissions
                .Where(t => t.RoleId == roleId)
                .AsEnumerable();

            return rolePermissionsQuery.ToList();
        }

        public async Task<RolePermission> AddRolePermission(RolePermission rolePermission)
        {
            return await AddAsync(rolePermission);
        }
        public async Task DeleteRolePermissionAsync(RolePermission rolePermission)
        {
            await DeleteAsync(rolePermission);
        }
        public async Task DeleteRolePermissionListAsync(List<int> rolePermissionId)
        {
            var rolePermission = await _dbContext.RolePermissions.Where(rolePermission => rolePermissionId.Contains(rolePermission.Id)).ToListAsync();
            await DeleteListAsync(rolePermission);
        }

        private IQueryable<RolePermissionResponseModelDTO> GetRolePermissionDetails()
        {
            return (from rol in _dbContext.Roles.AsNoTracking()
                               join rolPerm in _dbContext.RolePermissions.AsNoTracking() on rol.Id equals rolPerm.RoleId
                               join mod in _dbContext.Modules.AsNoTracking() on rolPerm.ModuleId equals mod.Id
                               join usrC in _dbContext.Users.AsNoTracking() on rol.CreatedBy equals usrC.Id
                               join usrU in _dbContext.Users.AsNoTracking() on rol.UpdatedBy equals usrU.Id into usrUX
                               from usrU in usrUX.DefaultIfEmpty()
                               orderby rol.Id descending
                               select new RolePermissionResponseModelDTO()
                               {
                                   Id = (int)rolPerm.Id,
                                   ModuleId = (int)rolPerm.ModuleId,
                                   RoleId = (int)rolPerm.RoleId,
                                   ModuleName = mod.Name,
                                   IsCreate = rolPerm.IsCreate == 'Y' ? true : false,
                                   IsRead = rolPerm.IsRead == 'Y' ? true : false,
                                   IsUpdate = rolPerm.IsUpdate == 'Y' ? true : false,
                                   DateRemoved = rolPerm.DateRemoved,
                                   CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                   CreatedAt = rol.CreatedAt,
                                   UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                   UpdatedAt = rol.UpdatedBy != null ? rol.UpdatedAt : null,
                               });
        }
        public async Task<List<RolePermissionResponseModelDTO>> GetRolePermissionListByRoleId(int? roleId)
        {
            return await GetRolePermissionDetails().Where(x=>x.Id == roleId).ToListAsync();
        }
    }
}