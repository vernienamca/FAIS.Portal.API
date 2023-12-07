using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _repository;

        public SettingsService(ISettingsRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Settings> Get()
        {
            return _repository.Get();
        }

        public async Task<Settings> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
