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
        public VersionsRepository(FAISContext context) : base(context) { }

        public IReadOnlyCollection<VersionModel> Get()
        {
            var versions = (from ver in _dbContext.Versions.AsNoTracking()
                            join usrC in _dbContext.Users.AsNoTracking() on ver.CreatedBy equals usrC.Id
                            orderby ver.Id descending
                            select new VersionModel()
                            {
                                Id = ver.Id,
                                VersionNo = ver.VersionNo,
                                VersionDate = ver.VersionDate,
                                Amendment = ver.Amendment,
                            }).ToList();

            return versions;
        }

        public async Task<Versions> Add(Versions version)
        {
            return await AddAsync(version);
        }

        public async Task<Versions> Update(Versions version)
        {
            return await UpdateAsync(version);
        }

        public async Task Delete(int id)
        {
            var result = _dbContext.Versions.FirstOrDefault(x=> x.Id == id);
            await DeleteAsync(result);
        }

        public async Task<Versions> GetById(int id)
        {
            return await _dbContext.Versions.FirstAsync(x => x.Id == id);
        }
    }
}
