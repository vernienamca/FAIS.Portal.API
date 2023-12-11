using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Services;
using FAIS.Infrastructure.Data;
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
            return _dbContext.Settings;
        }

        public Settings GetById(int id)
        {
            return _dbContext.Settings.Where(t => t.Id == id).ToList()[0];
        }
    }
}
