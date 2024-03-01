using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
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
    [Authorize]
    public class VersionController : Controller
    {
        #region Variables

        private readonly IVersionService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionController"/> class.
        /// <param name="versionService">The version entries service.</param>
        /// </summary>
        public VersionController(IVersionService service)
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the application versions.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<VersionModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Gets the version by unique identifier.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{id:int}")]
        [ProducesResponseType(typeof(Versions), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion

        #region Post

        /// <summary>
        /// Posts the create application version.
        /// </summary>
        /// <param name="versionDTO">The version data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">command</exception>
        [HttpPost]
        public async Task<IActionResult> PostCreateVersion([FromBody] AddVersionDTO versionDTO)
        {
            if (versionDTO == null)
                throw new ArgumentNullException(nameof(versionDTO));

            return Ok(await _service.Add(versionDTO));
        }

        #endregion Post
    }
}
