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

        #region STRING_INTERPOLATION
        public async Task<List<StringInterpolationModel>> GetStringInterpolation()
        {
            var stringInterpolation = (from interpolation in _dbContext.StringInterpolations.AsNoTracking()
                                       join usrC in _dbContext.Users.AsNoTracking() on interpolation.CreatedBy equals usrC.Id
                                       join usrU in _dbContext.Users.AsNoTracking() on interpolation.UpdatedBy equals usrU.Id into usrUX
                                       from usrU in usrUX.DefaultIfEmpty()
                                       select new StringInterpolationModel()
                                       {
                                           Id = interpolation.Id,
                                           TransactionCode = interpolation.TransactionCode,
                                           TransactionDescription = interpolation.TransactionDescription,
                                           IsActive = interpolation.IsActive,
                                           StatusDate = interpolation.StatusDate,
                                           NotificationType = interpolation.NotificationType,
                                           CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                           CreatedAt = interpolation.CreatedAt,
                                           UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                           UpdatedAt = interpolation.UpdatedAt
                                       }).ToListAsync();

            return await stringInterpolation;
        }

        public async Task<StringInterpolation> GetStringInterpolationById(int id)
        {
            return await _dbContext.StringInterpolations.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<StringInterpolation> AddStringInterpolation(StringInterpolation stringInterpolation)
        {
            return await AddAsync(stringInterpolation);
        }

        public async Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation stringInterpolation)
        {
            return await UpdateAsync(stringInterpolation);
        }

        #endregion

        #region TEMPLATES

        public async Task<List<TemplateModel>> GetTemplates()
        {
            var templates = (from template in _dbContext.Templates.AsNoTracking()
                                       join usrC in _dbContext.Users.AsNoTracking() on template.CreatedBy equals usrC.Id
                                       join usrU in _dbContext.Users.AsNoTracking() on template.UpdatedBy equals usrU.Id into usrUX
                                       from usrU in usrUX.DefaultIfEmpty()
                                       select new TemplateModel()
                                       {
                                           Id = template.Id,
                                           Subject = template.Subject,
                                           Content = template.Content,
                                           Receiver = template.Receiver,
                                           NotificationType = template.NotificationType,
                                           IsActive = template.IsActive,
                                           StatusDate = template.StatusDate,
                                           CreatedBy = $"{usrC.FirstName} {usrC.LastName}",
                                           CreatedAt = template.CreatedAt,
                                           UpdatedBy = $"{usrU.FirstName} {usrU.LastName}",
                                           UpdatedAt =  template.UpdatedAt
                                       }).ToListAsync();

            return await templates;
        }

        public async Task<Template> GetTemplateById(int id)
        {
            return await _dbContext.Templates.FirstOrDefaultAsync(o => o.Id == id);
        }

        #endregion


    }

}
