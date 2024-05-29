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
        Task<TemplateModel> GetTemplateById(int id);
        Task<StringInterpolation> AddInterpolation(AddStringInterpolationDTO interpolationDTO);
        Task<StringInterpolation> UpdateStringInterpolation(UpdateStringInterpolationDTO interpolationDTO);
        Task<StringInterpolation> DeleteStringInterpolation(int id);
        Task<Template> AddTemplate(AddTemplateDTO templateDTO);
        Task<Template> UpdateTemplate(UpdateTemplateDTO template);
        Task<Template> DeleteTemplate(int id);
    }
}
