using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IPermissionRepository
    {
        IReadOnlyCollection<PermissionModel> GetPermissions(int userId, int moduleId);
        IReadOnlyCollection<PermissionModel> Get();
        RolePermission GetById(int id);
        List<RolePermission> GetListById(int id);
        Task<RolePermission> Add(RolePermission permission);
        Task<RolePermission> Update(RolePermission permission);
        Task Delete(RolePermission permission);
        Task AddList(int roleId, List<RolePermission> permissionList);
    }
}
