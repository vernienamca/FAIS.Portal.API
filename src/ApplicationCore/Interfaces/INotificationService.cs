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
        IReadOnlyCollection<StringInterpolationModel> GetStringInterpolations();
        Task<StringInterpolation> GetStringInterpolationById(int id);
        IReadOnlyCollection<TemplateModel> GetNotificationTemplates();
        Task<Template> GetTemplateById(int id);
    }
}
