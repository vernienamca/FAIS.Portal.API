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

        public async Task<Settings> UpdateSettings(SettingsDTO updateSetting)
        {
            var settings = _repository.GetById(updateSetting.Id);
            settings.CompanyName = updateSetting.CompanyName;
            settings.PhoneNumber = updateSetting.PhoneNumber;
            settings.EmailAddress = updateSetting.EmailAddress;
            settings.Website = updateSetting.Website;
            settings.Address = updateSetting.Address;
            settings.SMTPPort = updateSetting.SMTPPort;
            settings.SMTPPassword = updateSetting.SMTPPassword;
            settings.SMTPFromEmail = updateSetting.SMTPFromEmail;
            settings.SMTPEnableSSL = updateSetting.SMTPEnableSSL;
            settings.SMTPServerName = updateSetting.SMTPServerName;
            settings.MinPasswordLength = updateSetting.MinPasswordLength;
            settings.MinSpecialCharacters = updateSetting.MinSpecialCharacters;
            settings.PasswordExpiry = updateSetting.PasswordExpiry;
            settings.IdleTime = updateSetting.IdleTime;
            settings.EnforcePasswordHistory = updateSetting.EnforcePasswordHistory;
            settings.MaxSignOnAttempts = updateSetting.MaxSignOnAttempts;
            settings.UpdatedBy = updateSetting.UpdatedBy;
            settings.UpdatedAt = DateTime.Now;
            return await _repository.Update(settings);
        }
    }
}
