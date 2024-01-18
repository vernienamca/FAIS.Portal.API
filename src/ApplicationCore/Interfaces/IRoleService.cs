using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IRoleService
    {
        IReadOnlyCollection<RoleModel> Get();
        Role GetById(int id);
        Task<Role> Update(int id);
        List<Role> GetUserRolesById(int userId);
    }
}
