using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class NotifcationRepository : EFRepository<StringInterpolation, int>, INotificationRepository
    {
        public NotifcationRepository(FAISContext context) : base(context)
        {
        }
        public IReadOnlyCollection<StringInterpolationModel> GetStringInterpolation()
        {
            var stringInterpolation = (from str in _dbContext.StringInterpolations.AsNoTracking()
                                       join usrC in _dbContext.Users.AsNoTracking() on str.CreatedBy equals usrC.Id
                                       join usrU in _dbContext.Users.AsNoTracking() on str.UpdatedBy equals usrU.Id into usrUX
                                       from usrU in usrUX.DefaultIfEmpty()
                                       select new StringInterpolationModel()
                                       {
                                           Id = str.Id,
                                           TransactionCode = str.TransactionCode,
                                           TransactionDescription = str.TransactionDescription,
                                           IsActive = str.IsActive,
                                           StatusDate = str.StatusDate,
                                           NotificationType = str.NotificationType,
                                           CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                           CreatedAt = str.CreatedAt,
                                           UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                           UpdatedAt = str.UpdatedAt
                                       }).ToList();

            return stringInterpolation;
        }
        public IReadOnlyCollection<TemplateModel> GetTemplates()
        {
            var templates = (from temp in _dbContext.Templates.AsNoTracking()
                             join usrC in _dbContext.Users.AsNoTracking() on temp.CreatedBy equals usrC.Id
                             join usrU in _dbContext.Users.AsNoTracking() on temp.UpdatedBy equals usrU.Id into usrUX
                             from usrU in usrUX.DefaultIfEmpty()
                             select new TemplateModel()
                             {
                                 Id = temp.Id,
                                 Subject = temp.Subject,
                                 Content = temp.Content,
                                 Receiver = temp.Receiver,
                                 NotificationType = temp.NotificationType,
                                 IsActive = temp.IsActive,
                                 StatusDate = temp.StatusDate,
                                 CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                 CreatedAt = temp.CreatedAt,
                                 UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                 UpdatedAt = temp.UpdatedAt
                             }).ToList();

            return templates;
        }
        public async Task<StringInterpolation> GetStringInterpolationById(int id)
        {
            return await _dbContext.StringInterpolations.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<Template> GetTemplateById(int id)
        {
            return await _dbContext.Templates.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<StringInterpolation> AddStringInterpolation(StringInterpolation stringInterpolation)
        {
            return await AddAsync(stringInterpolation);
        }
        public async Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation stringInterpolation)
        {
            return await UpdateAsync(stringInterpolation);
        }
    }
}
