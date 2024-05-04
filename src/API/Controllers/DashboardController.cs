using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        #region Variables

        private readonly IUserService _userService;
        private readonly IAuditLogService _auditLogService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardController"/> class.
        /// <param name="userService">The user service.</param>
        /// <param name="auditLogService">The audit log service.</param>
        /// </summary>
        public DashboardController(IUserService userService, IAuditLogService auditLogService)
        {
            _userService = userService;
            _auditLogService = auditLogService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// Gets the greeting based on the time of day.
        /// </summary>
        /// <returns></returns>
        [HttpGet("greeting/{userId:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGreeting(int userId)
        {
            var entity = await _userService.GetById(userId);
            string greeting = $"{DateTimeHelpers.GetGreetings()} {entity.FirstName}";

            await _auditLogService.Add(new AuditLogDTO()
            {
                ModuleSeq = 1,
                Activity = "Viewed the dashboard page",
                IpAddress = GeoLocationHelpers.GetClientIpAddress(),
                CreatedBy = userId,
                CreatedAt = DateTime.Now
            });

            return Ok(greeting);
        }

        #endregion Get
    }
}
