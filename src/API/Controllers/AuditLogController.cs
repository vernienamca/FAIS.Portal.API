using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        #region Variables

        private readonly IAuditLogService _auditLogService;
        private readonly ISettingsService _settingsService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogController"/> class.
        /// <param name="auditLogService">The audit log service.</param>
        /// <param name="userService">The user service.</param>
        /// </summary>
        public AuditLogController(IAuditLogService auditLogService 
            ,ISettingsService settingsService)
        {
            _auditLogService = auditLogService;
            _settingsService = settingsService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the audit logs.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AuditLogModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_auditLogService.Get());
        }

        /// <summary>
        /// Gets the audit logs by unique identifier.
        /// </summary>
        /// <param name="id">The audit logs identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AuditLog), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery] int id)
        {
            return Ok(_auditLogService.GetById(id));
        }

        /// <summary>
        /// Gets the exported logs file in bytes.
        /// </summary>
        /// <returns></returns>
        [HttpGet("export")]
        [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
        public IActionResult ExportLogs()
        {
            return File(_auditLogService.ExportAuditLogs(), System.Net.Mime.MediaTypeNames.Application.Octet, 
                $"logs_{DateTime.Now.Date}.xlsx");
        }

        /// <summary>
        /// Opens folder based on the configuration.
        /// </summary>
        /// <returns></returns>
        [HttpGet("open-folder")]
        public IActionResult OpenFolder()
        {
            Process.Start("explorer.exe", _settingsService.GetById(1).AuditLogsFilePath);

            return Ok();
        }

        #endregion Get
    }
}
