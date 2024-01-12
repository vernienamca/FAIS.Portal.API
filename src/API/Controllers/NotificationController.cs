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


        [HttpGet("[action]")]
        public IEnumerable<StringInterpolationModel> Get()
        {
            List<StringInterpolationModel> stringInterpolations = new List<StringInterpolationModel>();

            foreach (var stringInterpolation in _notificationService.Get())
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

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
        {
            var stringInterpolation = _notificationService.GetById(id);

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

        [HttpPost("[action]")]
        public async Task<IActionResult> AddStringInterpolation([FromBody] StringInterpolationDTO stringInterpolationDTO)
        {
            if (stringInterpolationDTO == null)
            {
                return BadRequest("StringInterpolationDTO is null");
            }

            var addedStringInterpolation = await _notificationService.AddStringInterpolation(stringInterpolationDTO);

            return CreatedAtAction(nameof(GetById), new { id = addedStringInterpolation.Id }, addedStringInterpolation);
        }

        /// <summary>
        /// 
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
    }
}