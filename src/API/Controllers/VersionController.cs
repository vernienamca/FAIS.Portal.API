using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class VersionController : Controller
    {
        #region Variables

        private readonly IVersionService _versionService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionController"/> class.
        /// <param name="versionService">The version entries service.</param>
        /// </summary>
        public VersionController(IVersionService versionService)
        {
            _versionService = versionService;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// List the version.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(List<VersionModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_versionService.GetListVersion());
        }

        /// <summary>
        /// List the version.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{id:int}")]
        [ProducesResponseType(typeof(List<VersionModel>), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_versionService.GetById(id));
        }
        #endregion

        #region post
        /// <summary>
        /// Add Version
        /// </summary>
        /// <param name="version">The version identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] AddVersionDTO version)
        {
            return Ok(_versionService.Add(version));
        }
        #endregion

        #region delete
        /// <summary>
        /// Delete Version
        /// </summary>
        /// <param name="version">The version identifier.</param>
        /// <returns></returns>
        [HttpDelete("[action]/{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok(_versionService.Delete(id));
        }
        #endregion
    }
}
