using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogController"/> class.
        /// </summary>
        public AuditLogController(IAuditLogService auditLogService, IUserService userService)
        {
            _auditLogService = auditLogService;
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IEnumerable<AuditLogModel> Get()
        {
            List<AuditLogModel> auditLogs = new List<AuditLogModel>();

            foreach (var auditLog in _auditLogService.Get())
            {
                var createdBy = _userService.GetById(auditLog.UserCreated);

                var entity = new AuditLogModel()
                {
                    Id = auditLog.Id,
                    Activity = auditLog.Activity,
                    DateCreated = System.DateTime.Now,
                    IpAddress = auditLog.IpAddress,
                    ModuleSeq = auditLog.ModuleSeq,
                    NewValues = auditLog.NewValues,
                    OldValues = auditLog.OldValues,
                    UserCreated = createdBy.Id
                };

                auditLogs.Add(entity);
            }

            return auditLogs;
        }

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
        {
            var entity = _auditLogService.GetById(id);

            var auditLog = new AuditLogModel()
            {
                Id = entity.Id,
                Activity = entity.Activity,
                DateCreated = System.DateTime.UtcNow,
                IpAddress = entity.IpAddress,
                ModuleSeq= entity.ModuleSeq,
                NewValues = entity.NewValues,
                OldValues= entity.OldValues,
            };

            return Ok(auditLog);
        }
    }
}
