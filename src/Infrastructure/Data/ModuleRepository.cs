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

        public async Task<Module> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
