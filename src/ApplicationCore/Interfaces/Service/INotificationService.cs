using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationService
    {
        IReadOnlyCollection<StringInterpolationModel> GetIntepolations();
        IReadOnlyCollection<TemplateModel> GetNotificationTemplates();
        Task<StringInterpolation> GetInterpolationById(int id);
        Task<Template> GetTemplateById(int id);
        Task<StringInterpolation> AddInterpolation(StringInterpolationDTO interpolationDTO);
        Task<StringInterpolation> UpdateStringInterpolation(StringInterpolation interpolation);
        Task<Template> AddTemplate(TemplateDto templateDTO);
        Task<Template> UpdateTemplate(Template template);
    }
}
