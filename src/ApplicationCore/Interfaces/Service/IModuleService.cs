using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IModuleService
    {
        IReadOnlyCollection<ModuleModel> Get();
        Module GetById(int id);
        Task<Module> Add(ModuleDTO moduleDto);
        Task<Module> Update(ModuleDTO moduleDto);
    }
}
