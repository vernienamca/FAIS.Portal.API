using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;

namespace FAIS.Infrastructure.Data
{
    public class AuditLogRepository : EFRepository<AuditLog, decimal>, IAuditLogRepository
    {
        public AuditLogRepository(FAISContext context) : base(context)
        {
        }

        public IQueryable<AuditLog> Get()
        {
            return _dbContext.AuditLogs;
        }

        public AuditLog GetById(decimal id)
        {
            return _dbContext.AuditLogs.Where(t => t.Id == id).ToList()[0];
        }
    }
}
