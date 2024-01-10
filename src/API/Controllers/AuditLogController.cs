using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FAIS.Portal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IUserService _userService;
        private readonly IModuleService _moduleService;
        private readonly ISettingsService _settingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogController"/> class.
        /// </summary>
        public AuditLogController(
            IAuditLogService auditLogService, 
            IUserService userService, 
            IModuleService moduleService,
            ISettingsService settingsService)
        {
            _auditLogService = auditLogService;
            _userService = userService;
            _moduleService = moduleService;
            _settingsService = settingsService;
        }

        [HttpGet("[action]")]
        public IEnumerable<AuditLogModel> Get()
        {
            List<AuditLogModel> auditLogs = new List<AuditLogModel>();

            foreach (var auditLog in _auditLogService.Get())
            {
                var createdBy = _userService.GetById(auditLog.UserCreated);
                var module = _moduleService.GetById((int)auditLog.ModuleSeq);

                var entity = new AuditLogModel()
                {
                    Id = auditLog.Id,
                    Activity = auditLog.Activity,
                    DateCreated = auditLog.DateCreated,
                    IpAddress = auditLog.IpAddress,
                    ModuleSeq = auditLog.ModuleSeq,
                    NewValues = auditLog.NewValues,
                    OldValues = auditLog.OldValues,
                    UserCreated = createdBy.Id,
                    CreatedBy = string.Format("{0} {1}", createdBy.FirstName, createdBy.LastName),
                    ModuleName = module.Name,
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

        [HttpGet("Export")]
        public IActionResult ExportAuditLogs()
        {
            var bytes = _auditLogService.ExportAuditLogs();
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, $"Audit_Logs_{ DateTime.Now.Date }.xlsx");
        }

        [HttpGet("OpenFolder")]
        public IActionResult OpenFolder()
        {
            var setting = _settingsService.GetById(1);
            Process.Start("explorer.exe", setting.AuditLogsFilePath);

            return Ok();
        }
    }
}
