using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class ModuleRepository : EFRepository<Module, int>, IModuleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleRepository"/> class.
        /// </summary>
        public ModuleRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<Module> Get()
        {
            return _dbContext.Modules.AsNoTracking();
        }

        public Module GetById(int id)
        {
            return _dbContext.Modules.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Module> Add(Module module)
        {
            return await AddAsync(module);
        }

        public async Task<Module> Update(Module role)
        {
            return await UpdateAsync(role);
        }
    }
}
