using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IUserRoleService
    {
        Task<IReadOnlyCollection<UserRoleModel>> Add(UserRoleModel userRoleModel);
    }
}
