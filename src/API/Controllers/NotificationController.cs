using System.Collections.Generic;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Threading.Tasks;
using System;
using DocumentFormat.OpenXml.Office2010.Excel;
using FAIS.ApplicationCore.Models;
using DocumentFormat.OpenXml.InkML;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
        [ProducesResponseType(typeof(StringInterpolationModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInterpolationById(int id)
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
                CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedAt = entity.CreatedAt
            };

            if (entity.UpdatedBy != null)
            {
                module.UpdatedBy = $"{createdBy.FirstName} {createdBy.LastName}";
                module.UpdatedAt = entity.UpdatedAt;
            }

            return Ok(module);
        }

        /// <summary>
        /// Gets the template by unique identifier.
        /// </summary>
        /// <param name="id">The template identifier.</param>
        /// <returns></returns>
        [HttpGet("template/{id:int}")]
        [ProducesResponseType(typeof(TemplateModel), StatusCodes.Status200OK)]
        public IActionResult GetTemplateById(int id)
        {
            return Ok(_notificationService.GetTemplateById(id));
        }
        #endregion

        #region Post

        /// <summary>
        /// Posts the create interpolation.
        /// </summary>
        /// <param name="interpolationDto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPost("interpolation")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCreateInterpolation(AddStringInterpolationDTO interpolationDTO)
        {
            if (interpolationDTO == null)
                throw new ArgumentNullException(nameof(interpolationDTO));

            return Ok(await _notificationService.AddInterpolation(interpolationDTO));
        }

        /// <summary>
        /// Posts the create template.
        /// </summary>
        /// <param name="templateDto">The template data object.</param>
        /// <returns></returns>
        [HttpPost("template")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCreateTemplate(AddTemplateDTO templateDTO)
        {
            if (templateDTO == null)
                throw new ArgumentNullException(nameof(templateDTO));

            return Ok(await _notificationService.AddTemplate(templateDTO));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update string interpolation.
        /// </summary>
        /// <param name="id">The string interpolation identifier.</param>
        /// <param name="dto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPut("interpolation/{id:int}")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutUpdateInterpolation(UpdateStringInterpolationDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var interpolation = await _notificationService.GetInterpolationById(dto.Id);
            if (dto.IsActive != interpolation.IsActive)
            {
                interpolation.IsActive = dto.IsActive;
                dto.StatusDate = DateTime.Now;
            }

            return Ok(_notificationService.UpdateStringInterpolation(dto));
        }

        /// <summary>
        /// Soft delete for string interpolation.
        /// </summary>
        /// <param name="id">The string interpolation identifier.</param>
        /// <param name="dto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPut("interpolation/delete/{id:int}")]
        [ProducesResponseType(typeof(StringInterpolation), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutDeleteInterpolation(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));
           
            return Ok(await _notificationService.DeleteStringInterpolation(id));
        }

        /// <summary>
        /// Puts the update template.
        /// </summary>
        /// <param name="id">The template identifier.</param>
        /// <param name="templateDTO">The template data object.</param>
        /// <returns></returns>
        [HttpPut("template/{id:int}")]
        [ProducesResponseType(typeof(Template), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutUpdateTemplate(UpdateTemplateDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var template = await _notificationService.GetTemplateById(dto.Id);
            if (dto.IsActive != template.IsActive)
            {
                template.IsActive = dto.IsActive;
                dto.StatusDate = DateTime.Now;
            }

            return Ok(_notificationService.UpdateTemplate(dto));

        }

        /// <summary>
        /// Soft delete for template.
        /// </summary>
        /// <param name="id">The template identifier.</param>
        /// <param name="dto">The template data object.</param>
        /// <returns></returns>
        [HttpPut("template/delete/{id:int}")]
        [ProducesResponseType(typeof(Template), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            return Ok(await _notificationService.DeleteTemplate(id));
        }
        #endregion
    }
}