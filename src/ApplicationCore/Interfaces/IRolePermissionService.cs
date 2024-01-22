using FAIS.ApplicationCore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IRolePermissionService
    {
        Task<List<RoleResponseModelDTO>> GetRolePermission();
        Task UpdateRolePermission(RoleRequestModelDTO roleModelDTO);
        Task DeletePermission(int id);
        Task<List<RoleResponseModelDTO>> GetListRolePermission();
        Task<RoleResponseModelDTO> GetListRolePermissionById(int id);
    }
}
