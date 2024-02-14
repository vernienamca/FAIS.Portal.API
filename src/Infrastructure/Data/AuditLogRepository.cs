using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Infrastructure.Data
{
    public class AuditLogRepository : EFRepository<AuditLog, int>, IAuditLogRepository
    {
        public AuditLogRepository(FAISContext context) : base(context)
        {
        }

        public IReadOnlyCollection<AuditLogModel> Get()
        {
            var auditLogs = (from log in _dbContext.AuditLogs.AsNoTracking()
                             join mod in _dbContext.Modules.AsNoTracking() on log.ModuleSeq equals mod.Id
                             join usr in _dbContext.Users.AsNoTracking() on log.CreatedBy equals usr.Id
                             select new AuditLogModel()
                             {
                                 Id = log.Id,
                                 ModuleName = mod.Name,
                                 Activity = log.Activity,
                                 NewValues = log.NewValues,
                                 OldValues = log.OldValues,
                                 IpAddress = log.IpAddress,
                                 CreatedBy = $"{usr.FirstName} {usr.LastName}",
                                 CreatedAt = log.CreatedAt
                             })
                             .OrderByDescending(t => t.CreatedAt)
                             .Where(l => l.CreatedAt.Date == DateTime.Now.Date)
                             .ToList();

            return auditLogs;
        }

        public AuditLog GetById(int id)
        {
            return _dbContext.AuditLogs.FirstOrDefault(t => t.Id == id);
        }

        public async Task<AuditLog> Add(AuditLog auditLog)
        {
            return await AddAsync(auditLog);
        }
    }
}
