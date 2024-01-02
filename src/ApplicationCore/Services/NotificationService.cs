using ArrayToExcel;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<StringInterpolation> Get()
        {
            return _repository.Get();
        }

        public StringInterpolation GetById(decimal id)
        {
            return _repository.GetById(id);
        }
    }
}
