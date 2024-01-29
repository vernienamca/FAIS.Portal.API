using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class PermissionRepository : EFRepository<RolePermission, int>, IPermissionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionRepository"/> class.
        /// </summary>
        public PermissionRepository(FAISContext context) : base(context)
        {

        }

        public IReadOnlyCollection<PermissionModel> Get()
        {
            var permission = (from perm in _dbContext.RolePermissions.AsNoTracking()
                              join mod in _dbContext.Modules.AsNoTracking() on perm.ModuleId equals mod.Id
                              orderby perm.Id descending
                         select new PermissionModel()
                         {
                             Id = perm.Id,
                             RoleId = perm.RoleId,
                             ModuleId = perm.ModuleId,
                             ModuleName = mod.Name,
                             GroupName = mod.GroupName,
                             IsCreate = perm.IsCreate == 'Y'? true : false,
                             IsRead = perm.IsRead == 'Y' ? true : false,
                             IsUpdate = perm.IsUpdate == 'Y' ? true : false,
                             Url = mod.Url,
                             Icon = mod.Icon
                         }).ToList();

            return permission;
        }

        public RolePermission GetById(int id)
        {
            return _dbContext.RolePermissions.Where(t => t.Id == id).ToList()[0];
        }
        public List<RolePermission> GetListById(int id)
        {
            return _dbContext.RolePermissions.Where(t => t.Id == id).ToList();
        }

        public async Task<RolePermission> Add(RolePermission permission)
        {
            return await AddAsync(permission);
        }

        public async Task<RolePermission> Update(RolePermission permission)
        {
            return await UpdateAsync(permission);
        } 
        public async Task Delete(RolePermission permission)
        {
            await DeleteAsync(permission);
        }

        public async Task AddList(int roleId, List<RolePermission> permissionList)
        {
            var perm = _dbContext.RolePermissions.Where(perm => perm.RoleId == roleId).ToList();
            if(perm.Count != 0)
            {
                _dbContext.RolePermissions.RemoveRange(perm);
                await _dbContext.SaveChangesAsync();
            }

            _dbContext.RolePermissions.AddRange(permissionList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
