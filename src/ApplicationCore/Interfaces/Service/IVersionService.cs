using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IVersionService
    {
        Task<List<VersionModel>> GetListVersion();
        Task<VersionModel> GetById(int id);
        Task<List<VersionModel>> Add(AddVersionDTO version);
        Task Delete(int id);
    }
}
