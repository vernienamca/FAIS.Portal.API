using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DepreciationController : ControllerBase
    {
        #region Variables

        private readonly IAuditLogService _auditLogService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DepreciationController"/> class.
        /// <param name="auditLogService">The audit log service.</param>
        /// </summary>
        public DepreciationController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        #endregion Constructor
    }
}
