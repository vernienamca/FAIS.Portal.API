using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ModuleRepository : EFRepository<Module, int>, IModuleRepository
    {
        public ModuleRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<Module> Get()
        {
            return _dbContext.Modules;
        }

        public Module GetById(int id)
        {
            return _dbContext.Modules.Where(t => t.Id == id).ToList()[0];
        }

        public async Task<Module> Add(Module module)
        {
            return await AddAsync(module);
        }
    }
}
