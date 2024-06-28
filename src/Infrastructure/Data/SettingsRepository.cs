using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

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

        public async Task<IReadOnlyCollection<EmailModel>> GetRecipients(int settingsId)
        {
            var setting = await _dbContext.Settings.AsNoTracking().FirstOrDefaultAsync(s => s.Id == settingsId);

            List<int> toRecipientRoleIds;
            List<int> ccRecipientRoleIds;

            switch (setting.ToRecipient)
            {
                case "0":
                    toRecipientRoleIds = await GetRoleIdsByDepartment("PAD");
                    break;

                case "-1":
                    toRecipientRoleIds = await GetRoleIdsByDepartment("ARMD");
                    break;

                default:
                    toRecipientRoleIds = setting.ToRecipient.Split(',')
                                                             .Select(roleId => Convert.ToInt32(roleId.Trim()))
                                                             .ToList();
                    break;
            }
            switch (setting.CcRecipient)
            {
                case "0":
                    ccRecipientRoleIds = await GetRoleIdsByDepartment("PAD");
                    break;

                case "-1":
                    ccRecipientRoleIds = await GetRoleIdsByDepartment("ARMD");
                    break;

                default:
                    ccRecipientRoleIds = setting.CcRecipient?.Split(',')
                                                             .Select(roleId => Convert.ToInt32(roleId.Trim()))
                                                             .ToList() ?? new List<int>();
                    break;
            }

            var toRecipients = await (from ur in _dbContext.UserRoles.AsNoTracking()
                                      join usr in _dbContext.Users.AsNoTracking() on ur.UserId equals usr.Id
                                      where toRecipientRoleIds.Contains(ur.RoleId)
                                      select usr.EmailAddress).ToListAsync();

            var ccRecipients = await (from ur in _dbContext.UserRoles.AsNoTracking()
                                      join usr in _dbContext.Users.AsNoTracking() on ur.UserId equals usr.Id
                                      where ccRecipientRoleIds.Contains(ur.RoleId)
                                      select usr.EmailAddress).ToListAsync();

            var toRecipient = string.Join(", ", toRecipients);
            var ccRecipient = string.Join(",", ccRecipients);

            var emailModel = new EmailModel
            {
                ToRecipient = toRecipients.AsReadOnly(),
                CcRecipient = ccRecipients.AsReadOnly()
            };

            return new List<EmailModel> { emailModel }.AsReadOnly();
        }

        public async Task<Settings> Add(Settings settings)
        {
            return await AddAsync(settings);
        }

        public async Task<Settings> Update(Settings settings)
        {
            return await UpdateAsync(settings);
        }

        private async Task<List<int>> GetRoleIdsByDepartment(string department )
        {
            return await (from ur in _dbContext.UserRoles.AsNoTracking()
                          join r in _dbContext.Roles.AsNoTracking() on ur.RoleId equals r.Id
                          where r.Name.Contains(department)
                          select ur.RoleId).ToListAsync();
        }
    }
}