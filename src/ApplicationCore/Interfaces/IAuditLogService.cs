using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IAuditLogService
    {
        IReadOnlyCollection<AuditLogModel> Get();
        AuditLog GetById(int id);
        byte[] ExportAuditLogs();
        Task<AuditLog> Add(AuditLogDTO auditLogDto);
    }
}
