using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using System;
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

        public Settings GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<Settings> Update(int id)
        {
            var settings = _repository.GetById(id);

            settings.UpdatedAt = DateTime.Now;

            return await _repository.Update(settings);
        }
    }
}
