using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
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

        public IReadOnlyCollection<ModuleModel> Get()
        {
            var modules = (from mod in _dbContext.Modules.AsNoTracking()
                         join usrC in _dbContext.Users.AsNoTracking() on mod.CreatedBy equals usrC.Id
                         join usrU in _dbContext.Users.AsNoTracking() on mod.UpdatedBy equals usrU.Id into usrUX
                         from usrU in usrUX.DefaultIfEmpty()
                         orderby mod.Id descending
                         select new ModuleModel()
                         {
                             Id = mod.Id,
                             Name = mod.Name,
                             Description = mod.Description,
                             Url = mod.Url,
                             Icon = mod.Icon,
                             GroupName = mod.GroupName,
                             Sequence = mod.Sequence,
                             IsActive = mod.IsActive,
                             StatusDate = mod.StatusDate,
                             CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                             CreatedAt = mod.CreatedAt,
                             UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                             UpdatedAt = mod.UpdatedBy != null ? mod.UpdatedAt : null,
                         }).ToList();

            return modules;
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
