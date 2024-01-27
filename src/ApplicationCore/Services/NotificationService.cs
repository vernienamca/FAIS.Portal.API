using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<StringInterpolationModel> GetIntepolations()
        {
            return _repository.GetIntepolations();
        }

        public IReadOnlyCollection<TemplateModel> GetNotificationTemplates()
        {
            return _repository.GetNotificationTemplates();
        }

        public async Task<Template> GetTemplateById(int id)
        {
            return await _repository.GetTemplateById(id);
        }

        public async Task<StringInterpolation> GetInterpolationById(int id)
        {
            return await _repository.GetInterpolationById(id);
        }
    }
}
