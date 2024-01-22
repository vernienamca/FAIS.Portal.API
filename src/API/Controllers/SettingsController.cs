using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController : Controller
    {
        #region Variables

        private readonly ISettingsService _settingsService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsController"/> class.
        /// <param name="settingsService">The module service.</param>
        /// </summary>
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        #endregion Constructor

        #region get
        /// <summary>
        /// List the Settings.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<SettingModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_settingsService.Get());
        }

        /// <summary>
        /// Get by Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<SettingModel>), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_settingsService.GetById(id));
        }
        #endregion

        #region update
        /// <summary>
        /// Updates the smptp only.
        /// </summary>
        /// <param name="update-smpt"></param>
        /// <returns></returns>
        [HttpPut("update-smpt")]
        [ProducesResponseType(typeof(SettingsDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSettingSmtp([FromBody] UpdateSmtpRequestDTO updateSmtpRequestDTO)
        {
            await _settingsService.UpdateSmtpById(updateSmtpRequestDTO);
            return Ok();
        }
        #endregion
    }
}
