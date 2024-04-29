using DocumentFormat.OpenXml.Drawing.Charts;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class TemplateRepository : EFRepository<Template, int>, ITemplateRepository
    {
        public TemplateRepository(FAISContext context) : base(context){ }
      
        public IReadOnlyCollection<TemplateModel> Get()
        {
            var templates = (from tmp in _dbContext.Templates.AsNoTracking()
                             join nft in _dbContext.LibraryTypes.Where(x => x.Code == "NFT").AsNoTracking() on tmp.NotificationType equals nft.Id
                             join usrC in _dbContext.Users.AsNoTracking() on tmp.CreatedBy equals usrC.Id
                             join usrU in _dbContext.Users.AsNoTracking() on tmp.UpdatedBy equals usrU.Id into usrUX
                             from usrU in usrUX.DefaultIfEmpty()
                             join rol2 in _dbContext.Roles.AsNoTracking() on tmp.Roles equals rol2.Id.ToString() into rol2x
                             from rol2 in rol2x.DefaultIfEmpty()
                             select new TemplateModel()
                             {
                                 Id = tmp.Id,
                                 Subject = tmp.Subject,
                                 Content = tmp.Content,
                                 NotificationType = tmp.NotificationType,
                                 NotificationTypeName = nft.Name,
                                 Roles = tmp.Roles,
                                 Users = tmp.Users,
                                 Icon = tmp.Icon,
                                 IconColor = tmp.IconColor,
                                 StartDate = tmp.StartDate,
                                 StartTime = tmp.StartTime,
                                 EndDate = tmp.EndDate,
                                 EndTime = tmp.EndTime,
                                 Target = tmp.Target,
                                 Url = tmp.Url,
                                 IsActive = tmp.IsActive,
                                 StatusDate = tmp.StatusDate,
                                 CreatedBy = tmp.CreatedBy,
                                 CreatedByName = $"{usrC.FirstName} {usrC.LastName}",
                                 CreatedAt = tmp.CreatedAt,
                                 UpdatedBy = tmp.UpdatedBy,
                                 UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = tmp.UpdatedAt
                             }).ToList();

            return templates;
        }

        public async Task<TemplateModel> GetById(int id)
        {
            var test = await _dbContext.Templates.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);

            var template = (from tmp in _dbContext.Templates.AsNoTracking()
                            //join rol in _dbContext.Roles.AsNoTracking() on tmp.Receiver equals rol.Id
                            join nft in _dbContext.LibraryTypes.Where(x => x.Code == "NFT").AsNoTracking() on tmp.NotificationType equals nft.Id
                            join usrC in _dbContext.Users.AsNoTracking() on tmp.CreatedBy equals usrC.Id
                            join usrU in _dbContext.Users.AsNoTracking() on tmp.UpdatedBy equals usrU.Id into usrUX
                            from usrU in usrUX.DefaultIfEmpty()
                            join rol2 in _dbContext.Roles.AsNoTracking() on tmp.Roles equals rol2.Id.ToString() into rol2x
                            from rol2 in rol2x.DefaultIfEmpty()
                            select new TemplateModel()
                             {
                                Id = tmp.Id,
                                Subject = tmp.Subject,
                                Content = tmp.Content,
                                NotificationType = tmp.NotificationType,
                                NotificationTypeName = nft.Name,
                                Roles = tmp.Roles,
                                Users = tmp.Users,
                                Icon = tmp.Icon,
                                IconColor = tmp.IconColor,
                                StartDate = tmp.StartDate,
                                StartTime = tmp.StartTime,
                                EndDate = tmp.EndDate,
                                EndTime = tmp.EndTime,
                                Target = tmp.Target,
                                Url = tmp.Url,
                                IsActive = tmp.IsActive,
                                StatusDate = tmp.StatusDate,
                                CreatedBy = tmp.CreatedBy,
                                CreatedByName = $"{usrC.FirstName} {usrC.LastName}",
                                CreatedAt = tmp.CreatedAt,
                                UpdatedBy = tmp.UpdatedBy,
                                UpdatedByName = $"{usrU.FirstName} {usrU.LastName}",
                                UpdatedAt = tmp.UpdatedAt
                             }).FirstOrDefaultAsync(t => t.Id == id);

            return await template;
        }

        public async Task<Template> Add(Template template)
        {
            return await AddAsync(template);
        }

        public async Task<Template> Update(Template template)
        {
            return await UpdateAsync(template);
        }
    }
}
