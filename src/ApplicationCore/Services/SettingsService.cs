using FAIS.ApplicationCore.DTOs;
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

        public async Task<Settings> UpdateSmtpById(UpdateSmtpRequestDTO updateSmtpRequestDTO)
        {
            var settings = _repository.GetById(updateSmtpRequestDTO.Id);
            settings.SMTPPort = updateSmtpRequestDTO.SMTPPort;
            settings.SMTPDisplayName = updateSmtpRequestDTO.SMTPDisplayName;
            settings.SMTPPassword = updateSmtpRequestDTO.SMTPPassword;
            settings.SMTPFromEmail = updateSmtpRequestDTO.SMTPFromEmail;
            settings.SMTPEnableSSL = updateSmtpRequestDTO.SMTPEnableSSL;
            settings.SMTPServerName = updateSmtpRequestDTO.SMTPServerName;

            settings.UpdatedAt = DateTime.Now;

            return await _repository.Update(settings);
        }

    }
}
