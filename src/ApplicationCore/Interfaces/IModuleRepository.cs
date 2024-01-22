using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IModuleRepository
    {
        IReadOnlyCollection<ModuleModel> Get();
        Module GetById(int id);
        Task<Module> Add(Module module);
        Task<Module> Update(Module module);
        Task Delete(Module module);
    }
}
