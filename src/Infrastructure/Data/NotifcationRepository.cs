using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class NotifcationRepository : EFRepository<StringInterpolation, decimal>, INotificationRepository
    {
        public NotifcationRepository(FAISContext context) : base(context)
        {
        }

        #region STRING_INTERPOLATION
        public async Task<List<StringInterpolation>> GetStringInterpolation()
        {
            return await _dbContext.StringInterpolations.OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<StringInterpolation> GetStringInterpolationById(decimal id)
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

        #region ALERTS

        public async Task<List<Alerts>> GetAlerts()
        {
            return await _dbContext.Alerts.OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Alerts> GetAlertsById(decimal id)
        {
            return await _dbContext.Alerts.FirstOrDefaultAsync(o => o.Id == id);
        }

        #endregion


    }

}
