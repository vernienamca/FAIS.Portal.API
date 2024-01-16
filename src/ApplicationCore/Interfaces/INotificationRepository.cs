using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationRepository
    {
        #region STRING_INTERPOLATION
        Task<List<StringInterpolationModel>> GetStringInterpolation();
        Task<StringInterpolation> GetStringInterpolationById(int id);
        Task<StringInterpolation> AddStringInterpolation(StringInterpolation stringInterpolation);
        Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation stringInterpolation);
        #endregion

        #region TEMPLATE
        Task<List<TemplateModel>> GetTemplates();
        Task<Template> GetTemplateById(int id);
        #endregion


    }
}
