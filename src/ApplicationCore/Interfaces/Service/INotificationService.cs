using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationService
    {
        IReadOnlyCollection<StringInterpolationModel> GetIntepolations();
        IReadOnlyCollection<TemplateModel> GetNotificationTemplates();
        Task<StringInterpolation> GetInterpolationById(int id);
        Task<Template> GetTemplateById(int id);
        Task<StringInterpolation> AddStringInterpolation(AddStringInterpolationDTO dto);
        Task<StringInterpolation> UpdateStringInterpolation(StringInterpolationDTO dto);
        Task<Template> AddTemplate(AddTemplateDto dto);
        Task<Template> UpdateTemplate(TemplateDto dto);
    }
}
