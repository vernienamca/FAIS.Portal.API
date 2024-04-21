using DocumentFormat.OpenXml.Office.Word;
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
                              join usrC in _dbContext.Users.AsNoTracking() on perm.CreatedBy equals usrC.Id
                              join usrU in _dbContext.Users.AsNoTracking() on perm.UpdatedBy equals usrU.Id into usrUX
                              from usrU in usrUX.DefaultIfEmpty()
                              orderby perm.Id descending
                              select new PermissionModel()
                              {
                                  Id = perm.Id,
                                  RoleId = perm.RoleId,
                                  ModuleId = perm.ModuleId,
                                  ModuleName = mod.Name,
                                  GroupName = mod.GroupName,
                                  IsCreate = perm.IsCreate == 'Y',
                                  IsRead = perm.IsRead == 'Y',
                                  IsUpdate = perm.IsUpdate == 'Y',
                                  Url = mod.Url,
                                  Icon = mod.Icon,
                                  CreatedBy = perm.CreatedBy,
                                  CreatedByName = $"{usrC.FirstName} {usrC.LastName}",
                                  CreatedAt = perm.CreatedAt,
                                  UpdatedBy = perm.UpdatedBy,
                                  UpdatedByName = perm.UpdatedBy.HasValue ? $"{usrU.FirstName} {usrU.LastName}" : "",
                                  UpdatedAt = perm.UpdatedAt != null ? perm.UpdatedAt : null,
                              }).ToList();

                return permission;
        }

        public IReadOnlyCollection<PermissionModel> GetPermissions(int userId, int moduleId)
        {
            var roles = _dbContext.UserRoles.AsNoTracking().Where(t => t.UserId == userId).Select(s => s.RoleId).ToList();

            var permissions = (from t in _dbContext.RolePermissions.AsNoTracking()
                               where roles.Any(a => a == t.RoleId) && t.ModuleId == moduleId
                               select new PermissionModel()
                               {
                                   Id = t.Id,
                                   RoleId = t.RoleId,
                                   ModuleId = t.ModuleId,
                                   IsCreate = t.IsCreate == 'Y',
                                   IsRead = t.IsRead == 'Y',
                                   IsUpdate = t.IsUpdate == 'Y'
                               }).ToList();

            return permissions;
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
