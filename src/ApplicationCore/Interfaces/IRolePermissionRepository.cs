using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IRolePermissionRepository
    {
        RolePermission GetById(int id);
        List<RolePermission> GetListById(int id);
        Task<RolePermission> UpdateRolePermission(RolePermission rolePermission);
        Task<RolePermission> AddRolePermission(RolePermission rolePermission);
        Task DeleteRolePermissionAsync(RolePermission rolePermission);
        Task DeleteRolePermissionListAsync(List<int> rolePermissionId);
        Task<List<RolePermissionResponseModelDTO>> GetRolePermissionListByRoleId(int? roleId);
    }
}
