using FAIS.ApplicationCore.Entities.Security;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IAuditLogRepository
    {
        IQueryable<AuditLog> Get();
        AuditLog GetById(decimal id);
    }
}
