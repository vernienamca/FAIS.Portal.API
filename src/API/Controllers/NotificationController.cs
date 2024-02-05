using System.Collections.Generic;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Threading.Tasks;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
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
        /// <param name="notificationService">The notification service.</param>
        /// </summary>
        public NotificationController(INotificationService notificationService, IUserService userService)
        {
            _notificationService = notificationService;
            _userService = userService;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// List the string interpolations.
        /// </summary>
        [HttpGet("interpolations")]
        [ProducesResponseType(typeof(IReadOnlyCollection<StringInterpolationModel>), StatusCodes.Status200OK)]
        public IActionResult GetInterpolations()
        {
            return Ok(_notificationService.GetIntepolations());
        }
        /// <summary>
        /// List the notification templates.
        /// </summary>
        /// <returns>Template list</returns>
        [HttpGet("templates")]
        [ProducesResponseType(typeof(IReadOnlyCollection<NotificationTemplateModel>), StatusCodes.Status200OK)]
        public IActionResult GetNotificationTemplates()
        {
            return Ok(_notificationService.GetNotificationTemplates());
        }

        /// <summary>
        /// Gets the string interpolation by unique identifier.
        /// </summary>
        /// <param name="id">The string interpolation identifier.</param>
        /// <returns></returns>
        [HttpGet("interpolation/{id:int}")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _notificationService.GetInterpolationById(id);
            var createdBy = await _userService.GetById(entity.CreatedBy);

            var module = new StringInterpolationModel()
            {
                Id = entity.Id,
                TransactionCode = entity.TransactionCode,
                Description = entity.Description,
                IsActive = entity.IsActive,
                StatusDate = entity.StatusDate,
                NotificationType = entity.NotificationType,
                CreatedByDisplay = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedBy = entity.CreatedBy,
                CreatedAt = entity.CreatedAt
            };

            if (entity.UpdatedBy != null)
            {
                module.UpdatedBy = $"{createdBy.FirstName} {createdBy.LastName}";
                module.UpdatedAt = entity.UpdatedAt;
            }

            return Ok(module);
        }
        #endregion

        #region post
        /// <summary>
        /// Posts the create interpolation.
        /// </summary>
        /// <param name="interpolationDto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPost("add/interpolation")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public IActionResult AddStringInterpolation(AddStringInterpolationDTO interpolationDto)
        {
            return Ok(_notificationService.AddStringInterpolation(interpolationDto));
        }
        /// <summary>
        /// Puts the update string interpolation.
        /// </summary>
        /// <param name="interpolationDto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPut("interpolation")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public IActionResult UpdateStringInterpolation(StringInterpolationDTO interpolationDto)
        {
            return Ok(_notificationService.UpdateStringInterpolation(interpolationDto));
        }
        #endregion
    }
}