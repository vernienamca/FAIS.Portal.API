using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRoleService
    {
        IReadOnlyCollection<UserRoleModel> Get();
        IReadOnlyCollection<string> GetUserEmailsByRole(string role);

    }
}
