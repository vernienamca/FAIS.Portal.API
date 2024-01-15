using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IAuditLogRepository
    {
        IReadOnlyCollection<AuditLogModel> Get();
        AuditLog GetById(int id);
        Task<AuditLog> Add(AuditLog auditLog);
    }
}
