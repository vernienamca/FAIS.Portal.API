using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IVersionsRepository
    {
        IReadOnlyCollection<VersionModel> Get();
        Task<Versions> GetById(int id);
        Task<Versions> Add(Versions version);
        Task<Versions> Update(Versions version);
        Task Delete(int id);
    }
}
