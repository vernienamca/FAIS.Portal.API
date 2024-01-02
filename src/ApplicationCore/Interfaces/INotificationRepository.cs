using FAIS.ApplicationCore.Entities.Security;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<StringInterpolation> Get();
        StringInterpolation GetById(decimal id);
    }
}
