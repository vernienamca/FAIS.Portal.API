﻿using System.Collections.Generic;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Services;

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
        #endregion

        #region post
        /// <summary>
        /// Posts the create interpolation.
        /// </summary>
        /// <param name="interpolationDto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPost("add/interpolation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddStringInterpolation(AddStringInterpolationDTO interpolationDto)
        {
            return Ok(_notificationService.AddStringInterpolation(interpolationDto));
        }
        /// <summary>
        /// Puts the update string interpolation.
        /// </summary>
        /// <param name="interpolationDto">The interpolation data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateStringInterpolation(StringInterpolationDTO interpolationDto)
        {
            return Ok(_notificationService.UpdateStringInterpolation(interpolationDto));
        }
        #endregion
    }
}