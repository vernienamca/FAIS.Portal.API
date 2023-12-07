using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repository;

        public ModuleService(IModuleRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Module> Get()
        {
            return _repository.Get();
        }

        public async Task<Module> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
