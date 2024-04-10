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
                             join rol in _dbContext.Roles.AsNoTracking() on tmp.Receiver equals rol.Id
                             join nft in _dbContext.LibraryTypes.Where(x => x.Code == "NFT").AsNoTracking() on tmp.NotificationType equals nft.Id
                             join usrC in _dbContext.Users.AsNoTracking() on tmp.CreatedBy equals usrC.Id
                             join usrU in _dbContext.Users.AsNoTracking() on tmp.UpdatedBy equals usrU.Id into usrUX
                             from usrU in usrUX.DefaultIfEmpty()
                             select new TemplateModel()
                             {
                                 Id = tmp.Id,
                                 Subject = tmp.Subject,
                                 Content = tmp.Content,
                                 ReceiverName = rol.Name,
                                 NotificationTypeName = nft.Name,
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
            var template = (from temp in _dbContext.Templates.AsNoTracking()
                            join usr in _dbContext.Users.AsNoTracking() on temp.CreatedBy equals usr.Id
                            join usrU in _dbContext.Users.AsNoTracking() on temp.UpdatedBy equals usrU.Id into usrUX
                            from usrU in usrUX.DefaultIfEmpty()
                            orderby temp.Id descending
                            select new TemplateModel()
                            {
                                Id = temp.Id,
                                Subject = temp.Subject,
                                Content = temp.Content,
                                Receiver = temp.Receiver,
                                NotificationType = temp.NotificationType,
                                IsActive = temp.IsActive,
                                StatusDate = temp.StatusDate,
                                CreatedBy = temp.CreatedBy,
                                CreatedByName = $"{usr.FirstName} {usr.LastName}",
                                CreatedAt = temp.CreatedAt,
                                UpdatedAt = temp.UpdatedAt,
                                UpdatedByName = $"{usrU.FirstName} {usrU.LastName}"
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
