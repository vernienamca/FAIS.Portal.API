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
        IReadOnlyCollection<StringInterpolationModel> GetIntepolations();
        IReadOnlyCollection<TemplateModel> GetNotificationTemplates();
        Task<StringInterpolation> GetInterpolationById(int id);
        Task<Template> GetTemplateById(int id);
        Task<StringInterpolation> AddStringInterpolation(StringInterpolation interpolation);
        Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation interpolation);

    }
}
