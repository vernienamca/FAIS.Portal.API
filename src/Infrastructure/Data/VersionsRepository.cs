using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class VersionsRepository : EFRepository<Versions, int>, IVersionsRepository
    {
        public VersionsRepository(FAISContext context) : base(context)
        {
        }
        public IQueryable<VersionModel> Get()
        {
            return _dbContext.Versions.AsNoTracking();
        }

        public async Task<Versions> Add(Versions userRole)
        {
            return await AddAsync(userRole);
        }

        public async Task<Versions> Update(Versions userRole)
        {
            return await UpdateAsync(userRole);
        }

        IReadOnlyCollection<RoleModel> IVersionsRepository.Get()
        {
            throw new System.NotImplementedException();
        }

        public Versions GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
