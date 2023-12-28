using ArrayToExcel;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repository;

        public AuditLogService(IAuditLogRepository repository)
        {
            _repository = repository;
        }

        public byte[] ExportAuditLogs()
        {
            var logs = _repository.Get();
            return logs.ToList().ToExcel();
        }

        public IQueryable<AuditLog> Get()
        {
            return _repository.Get();
        }

        public AuditLog GetById(decimal id)
        {
            return _repository.GetById(id);
        }
    }
}
