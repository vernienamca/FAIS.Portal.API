
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IPermissionService
    {
        List<PermissionModel> GetListPermission();
        Task DeletePermission(int id);
        Task AddPermission(PermissionDTO permissionDTO);
        List<PermissionModel> GetListPermissionByRoleId(int roleId);
        RolePermissionModel GetRolePermissionListByRoleId(int roleId);
    }
}
