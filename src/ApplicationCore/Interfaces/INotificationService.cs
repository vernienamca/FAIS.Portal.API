using FAIS.ApplicationCore.Entities.Security;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface INotificationService
    {
        IQueryable<StringInterpolation> Get();
        StringInterpolation GetById(decimal id);

    }
}
