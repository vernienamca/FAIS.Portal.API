using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationService
    {
        #region STRING_INTERPOLATION
        Task<List<StringInterpolation>> GetStringInterpolation();
        Task<StringInterpolation> GetStringInterpolationById(decimal id);
        Task<StringInterpolation> AddStringInterpolation(StringInterpolationDTO userDTO);
        Task<StringInterpolation> UpdateStringInterpolation(decimal id, StringInterpolationDTO userDTO);
        #endregion

        #region ALERTS
        Task<List<Alerts>> GetAlerts();
        Task<Alerts> GetAlertsById(decimal id);
        #endregion

    }
}
