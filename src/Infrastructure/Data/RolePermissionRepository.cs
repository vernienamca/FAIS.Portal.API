using DocumentFormat.OpenXml.Office2010.Excel;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class RolePermissionRepository : EFRepository<RolePermission, decimal>, IRolePermissionRepository
    {
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

        public async Task<List<RolePermission>> GetRolePermissionByRoleId(int roleId)
        {
            return await _dbContext.RolePermissions.Where(t => t.RoleId == roleId).ToListAsync();
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
