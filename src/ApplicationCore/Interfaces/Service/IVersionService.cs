using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IVersionService
    {
        IReadOnlyCollection<VersionModel> Get();
        Task<Versions> GetById(int id);
        Task<Versions> Add(AddVersionDTO versionDTO);
        Task Delete(int id);
    }
}
