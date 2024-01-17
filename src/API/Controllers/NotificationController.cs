using System.Collections.Generic;
using FAIS.ApplicationCore.DTOs;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        #region Variables

        private readonly INotificationService _notificationService;

        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationController"/> class.
        /// </summary>
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationController"/> class.
        /// <param name="notificationService">The notification service.</param>
        /// </summary>
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        #endregion Constructor

        #region String Interpolation
        /// <summary>
        /// Get String Interpolation List
        /// </summary>
        /// <returns>String Interpolation list</returns>
        [HttpGet("interpolations")]
        [ProducesResponseType(typeof(IReadOnlyCollection<StringInterpolationModel>), StatusCodes.Status200OK)]
        public IActionResult GetStringInterpolations()
        {
            return Ok(_notificationService.GetStringInterpolations());
        }
        #endregion

        #region Templates
        /// <summary>
        /// Get templates List
        /// </summary>
        /// <returns>Template list</returns>
        [HttpGet("templates")]
        [ProducesResponseType(typeof(List<TemplateModel>), StatusCodes.Status200OK)]
        public IActionResult GetTemplates()
        {
            return Ok(_notificationService.GetTemplates());
        }           
        #endregion

    }
}