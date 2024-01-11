using FAIS.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IRolePermissionService
    {
        Task<List<RoleModelDTO>> GetRolePermission();
        Task DeletePermission(int id);
        Task<RoleModelDTO> GetRolePermissionById(int id);
        Task<RoleModelDTO> UpdateRolePermission(RoleModelDTO permissions);
    }
}
