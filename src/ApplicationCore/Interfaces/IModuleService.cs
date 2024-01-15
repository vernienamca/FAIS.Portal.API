using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IModuleService
    {
        IQueryable<Module> Get();
        Module GetById(int id);
        Task<Module> Add(ModuleDTO moduleDto);
        Task<Module> Update(ModuleDTO moduleDto);
        Task Delete(int id);
    }
}
