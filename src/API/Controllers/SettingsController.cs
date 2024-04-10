using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class SettingsController : Controller
    {
        #region Variables

        private readonly ISettingsService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsController"/> class.
        /// <param name="service">The settings service.</param>
        /// </summary>
        public SettingsController(ISettingsService service)
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the settings.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<SettingModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Gets the settings by unique identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<SettingModel>), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Put

        /// <summary>
        /// Puts the update system settings.
        /// </summary>
        /// <param name="settingsDTO">The settings data object.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutUpdateSettings([FromBody] SettingsDTO settingsDTO)
        {
            var settings = _service.GetById(1);

            settings.CompanyName = settingsDTO.CompanyName;
            settings.PhoneNumber = settingsDTO.PhoneNumber;
            settings.EmailAddress = settingsDTO.EmailAddress;
            settings.Website = settingsDTO.Website;
            settings.Address = settingsDTO.Address;
            settings.MinPasswordLength = settingsDTO.MinPasswordLength;
            settings.MinSpecialCharacters = settingsDTO.MinSpecialCharacters;
            settings.PasswordExpiry = settingsDTO.PasswordExpiry;
            settings.IdleTime = settingsDTO.IdleTime;
            settings.MaxSignOnAttempts = settingsDTO.MaxSignOnAttempts;
            settings.EnforcePasswordHistory = settingsDTO.EnforcePasswordHistory;
            settings.SMTPServerName = settingsDTO.SMTPServerName;
            settings.SMTPPort = settingsDTO.SMTPPort;
            settings.SMTPFromEmail = settingsDTO.SMTPFromEmail;
            settings.SMTPPassword = settingsDTO.SMTPPassword;
            settings.SMTPEnableSSL = settingsDTO.SMTPEnableSSL;
            settings.UpdatedBy = settingsDTO.UpdatedBy;
            settings.UpdatedAt = DateTime.Now;

            return Ok(await _service.Update(settings));
        }

        #endregion Put
    }
}
