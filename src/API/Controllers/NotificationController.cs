using System.Collections.Generic;
using FAIS.ApplicationCore.DTOs;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class NotificationController : ControllerBase
    {
        #region Variables

        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationController"/> class.
        /// </summary>
        public NotificationController(INotificationService notificationService, IUserService userService)
        {
            _notificationService = notificationService;
            _userService = userService;
        }

        #endregion Constructor


        #region STRING_INTERPOLATION
        /// <summary>
        /// Get String Interpolation List
        /// </summary>
        /// <returns>String Interpolation list</returns>
        [HttpGet("interpolations")]
        [ProducesResponseType(typeof(List<StringInterpolationModel>), StatusCodes.Status200OK)]
        public IActionResult GetStringInterpolations()
        {
            return Ok(_notificationService.GetStringInterpolations());
        }
        #endregion


        #region TEMPLATES
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