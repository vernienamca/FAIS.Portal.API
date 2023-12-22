using FAIS.ApplicationCore.Entities.Security;
using System.Linq;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IAuditLogService
    {
        IQueryable<AuditLog> Get();
        AuditLog GetById(decimal id);
    }
}
