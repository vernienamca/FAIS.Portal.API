using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class SettingsRepository : EFRepository<Settings, int>, ISettingsRepository
    {
        public SettingsRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<Settings> Get()
        {
            return _dbContext.Settings.AsNoTracking();
        }

        public Settings GetById(int id)
        {
            return _dbContext.Settings.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Settings> Add(Settings settings)
        {
            return await AddAsync(settings);
        }

        public async Task<Settings> Update(Settings settings)
        {
            return await UpdateAsync(settings);
        }
    }
}
