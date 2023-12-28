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
            // take latest 100 records only.
            return _dbContext.AuditLogs.OrderByDescending(o => o.DateCreated).Take(100);
        }

        public AuditLog GetById(decimal id)
        {
            return _dbContext.AuditLogs.Where(t => t.Id == id).ToList()[0];
        }
    }
}
