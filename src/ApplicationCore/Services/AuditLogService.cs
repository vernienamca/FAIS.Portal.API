using ArrayToExcel;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repository;

        public AuditLogService(IAuditLogRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyCollection<AuditLogModel> Get()
        {
            return _repository.Get();
        }

        public AuditLog GetById(int id)
        {
            return _repository.GetById(id);
        }

        public byte[] ExportAuditLogs()
        {
            return _repository.Get().ToExcel();
        }

        public async Task<AuditLog> Add(AuditLogDTO auditLogDto)
        {
            try
            {
                var auditLog = new AuditLog()
                {
                    ModuleSeq = auditLogDto.ModuleSeq,
                    Activity = auditLogDto.Activity,
                    OldValues = auditLogDto.OldValues,
                    NewValues = auditLogDto.NewValues,
                    IpAddress = auditLogDto.IpAddress,
                    CreatedBy = auditLogDto.CreatedBy,
                    CreatedAt = DateTime.Now
                };

                return await _repository.Add(auditLog);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
