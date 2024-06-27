using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<EmailModel>> GetRecipients(int settingsId)
        {
            return await _repository.GetRecipients(settingsId);
        }
        public async Task<Settings> Update(Settings settings)
        {
            return await _repository.Update(settings);
        }
    }
}
