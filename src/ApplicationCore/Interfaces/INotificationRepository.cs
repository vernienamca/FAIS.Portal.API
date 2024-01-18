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
        IReadOnlyCollection<StringInterpolationModel> GetStringInterpolation();
        IReadOnlyCollection<TemplateModel> GetNotificationTemplates();
        Task<StringInterpolation> GetStringInterpolationById(int id);
        Task<StringInterpolation> AddStringInterpolation(StringInterpolation stringInterpolation);
        Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation stringInterpolation);
        Task<Template> GetTemplateById(int id);

    }
}
