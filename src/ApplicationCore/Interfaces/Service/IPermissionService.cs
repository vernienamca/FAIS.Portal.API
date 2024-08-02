using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IPermissionService
    {
        IReadOnlyCollection<PermissionModel> Get();
        IReadOnlyCollection<PermissionModel> GetPermissions(int userId, int moduleId);
        List<PermissionModel> GetListPermission();
        Task DeletePermission(int id);
        Task AddPermission(AddPermissionDTO permissionDTO);
        Task UpdatePermission(UpdatePermissionDTO permissionDTO);
        List<PermissionModel> GetListPermissionByRoleId(int roleId);
        RolePermissionModel GetRolePermissionListByRoleId(int roleId);
        Task UpdateRoleAddPermission(UpdateRolePermissionDTO rolePermission);
    }
}
