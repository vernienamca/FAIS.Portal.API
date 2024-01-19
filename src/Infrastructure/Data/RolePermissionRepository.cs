using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public IQueryable<RolePermission> Get()
        {
            return _dbContext.RolePermissions;
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
        public async Task DeleteRolePermissionListAsync(List<RolePermission> rolePermissions)
        {
            await DeleteListAsync(rolePermissions);
        }        
    }
}