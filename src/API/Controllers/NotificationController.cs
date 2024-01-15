using System;
using System.Collections.Generic;
using FAIS.ApplicationCore.DTOs;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.X509;
using FAIS.ApplicationCore.Models;
using System.Linq;
using FAIS.ApplicationCore.Services;
using FAIS.ApplicationCore.Entities.Security;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Drawing.Charts;

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
        public async Task<IEnumerable<StringInterpolationModel>> GetStringInterpolation()
        {
            List<StringInterpolationModel> stringInterpolations = new List<StringInterpolationModel>();

            foreach (var stringInterpolation in await _notificationService.GetStringInterpolation())
            {
                var createdBy = _userService.GetById(stringInterpolation.CreatedBy);
                var modifiedBy = _userService.GetById(stringInterpolation.UpdatedBy.Value);

                var entity = new StringInterpolationModel()
                {
                    Id = stringInterpolation.Id,
                    TransactionCode = stringInterpolation.TransactionCode,
                    TransactionDescription = stringInterpolation.TransactionDescription,
                    IsActive = stringInterpolation.IsActive,
                    StatusDate = stringInterpolation.StatusDate,
                    NotificationType = stringInterpolation.NotificationType,
                    CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                    CreatedAt = stringInterpolation.CreatedAt,
                };

                if (modifiedBy != null)
                {
                    entity.UpdatedBy = $"{modifiedBy.FirstName} {modifiedBy.LastName}";
                    entity.UpdatedAt = stringInterpolation.UpdatedAt;
                }

                stringInterpolations.Add(entity);
            }

            return stringInterpolations;
        }

        /// <summary>
        /// Get String Interpolation By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String Interpolation details</returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStringInterpolationById([FromQuery] int id)
        {
            var stringInterpolation = await _notificationService.GetStringInterpolationById(id);

            var createdBy = _userService.GetById(stringInterpolation.CreatedBy);
            var modifiedBy = _userService.GetById(stringInterpolation.UpdatedBy.Value);

            var returnValue = new StringInterpolationModel()
            {
                Id = stringInterpolation.Id,
                TransactionCode = stringInterpolation.TransactionCode,
                TransactionDescription = stringInterpolation.TransactionDescription,
                IsActive = stringInterpolation.IsActive,
                StatusDate = stringInterpolation.StatusDate,
                NotificationType = stringInterpolation.NotificationType,
                CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedAt = stringInterpolation.CreatedAt,
            };

            if (modifiedBy != null)
            {
                returnValue.UpdatedBy = $"{modifiedBy.FirstName} {modifiedBy.LastName}";
                returnValue.UpdatedAt = stringInterpolation.UpdatedAt;
            }

            return Ok(returnValue);
        }

        /// <summary>
        /// Add String Interpolation
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddStringInterpolation([FromBody] StringInterpolationDTO stringInterpolationDTO)
        {
            if (stringInterpolationDTO == null)
            {
                return BadRequest("StringInterpolationDTO is null");
            }

            var addedStringInterpolation = await _notificationService.AddStringInterpolation(stringInterpolationDTO);

            return CreatedAtAction(nameof(GetStringInterpolationById), new { id = addedStringInterpolation.Id }, addedStringInterpolation);
        }

        /// <summary>
        /// Update String Interpolation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stringInterpolationDTO"></param>
        /// <returns></returns>
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> UpdateStringInterpolation(decimal id, [FromBody] StringInterpolationDTO stringInterpolationDTO)
        {
            if (id <= 0 || stringInterpolationDTO == null)
            {
                return BadRequest("Invalid input");
            }
            var update = await _notificationService.UpdateStringInterpolation(id, stringInterpolationDTO);
            return Ok(update);
        }
        #endregion


        #region ALERTS
        /// <summary>
        /// Get alerts List
        /// </summary>
        /// <returns>Alert list</returns>
        [HttpGet("templates")]
        public async Task<IEnumerable<AlertsModel>> GetAlerts()
        {
            List<AlertsModel> alerts = new List<AlertsModel>();

            foreach (var alert in await _notificationService.GetAlerts())
            {
                var createdBy = _userService.GetById(alert.CreatedBy);
                var modifiedBy = _userService.GetById(alert.UpdatedBy.Value);

                var entity = new AlertsModel()
                {
                    Id = alert.Id,
                    Subject = alert.Subject,
                    Content = alert.Content,
                    Receiver = alert.Receiver,
                    NotificationType = alert.NotificationType,
                    IsActive = alert.IsActive,
                    StatusDate = alert.StatusDate,
                    
                    CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                    CreatedAt = alert.CreatedAt,
                };

                if (modifiedBy != null)
                {
                    entity.UpdatedBy = $"{modifiedBy.FirstName} {modifiedBy.LastName}";
                    entity.UpdatedAt = alert.UpdatedAt;
                }

                alerts.Add(entity);
            }

            return alerts;
        }

        /// <summary>
        /// Get Alerts By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Alert details</returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAlertsById([FromQuery] int id)
        {
            var alert = await _notificationService.GetAlertsById(id);

            var createdBy = _userService.GetById(alert.CreatedBy);
            var modifiedBy = _userService.GetById(alert.UpdatedBy.Value);

            var returnValue = new AlertsModel()
            {
                Id = alert.Id,
                Subject = alert.Subject,
                Content = alert.Content,
                Receiver = alert.Receiver,
                NotificationType = alert.NotificationType,
                IsActive = alert.IsActive,
                StatusDate = alert.StatusDate,

                CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedAt = alert.CreatedAt,
            };
            if (modifiedBy != null)
            {
                returnValue.UpdatedBy = $"{modifiedBy.FirstName} {modifiedBy.LastName}";
                returnValue.UpdatedAt = alert.UpdatedAt;
            }

            return Ok(returnValue);
        }
        #endregion

    }
}