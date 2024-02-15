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
                                 Receiver = rol.Name,
                                 NotificationType = nft.Name,
                                 IsActive = tmp.IsActive,
                                 StatusDate = tmp.StatusDate,
                                 CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                 CreatedAt = tmp.CreatedAt,
                                 UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = tmp.UpdatedAt
                             }).ToList();

            return templates;
        }

        public async Task<Template> GetById(int id)
        {
            return await _dbContext.Templates.FirstOrDefaultAsync(t => t.Id == id);
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
