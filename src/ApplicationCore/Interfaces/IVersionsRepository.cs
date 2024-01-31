
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IVersionsRepository
    {
        IReadOnlyCollection<RoleModel> Get();
        Versions GetById(int id);
        Task<Versions> Add(Versions version);
        Task<Versions> Update(Versions version);
    }
}
