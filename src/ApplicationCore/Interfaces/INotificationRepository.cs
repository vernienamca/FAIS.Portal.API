using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationRepository
    {
        #region STRING_INTERPOLATION
        Task<List<StringInterpolation>> GetStringInterpolation();
        Task<StringInterpolation> GetStringInterpolationById(decimal id);
        Task<StringInterpolation> AddStringInterpolation(StringInterpolation stringInterpolation);
        Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation stringInterpolation);
        #endregion

        #region ALERTS
        Task<List<Alerts>> GetAlerts();
        Task<Alerts> GetAlertsById(decimal id);
        #endregion


    }
}
