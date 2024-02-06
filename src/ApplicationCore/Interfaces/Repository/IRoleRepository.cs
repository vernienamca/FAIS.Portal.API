using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IRoleRepository
    {
        IReadOnlyCollection<RoleModel> Get();
        Role GetById(int id);
        Task<Role> Add(Role role);
        Task<Role> Update(Role role);
        IReadOnlyCollection<Role> GetUserRolesById(int id);
        Role GetRoleIdByName(string RoleName);
    }
}
