using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAIS.ApplicationCore.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repository;

        public AuditLogService(IAuditLogRepository repository)
        {
            _repository = repository;
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
