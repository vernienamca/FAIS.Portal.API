using System;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Interfaces.Service;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectProfileController : ControllerBase
    {
        #region Variables

        private readonly IProjectProfileService _projectProfileService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectProfileController"/> class.
        /// <param name="projectProfileService">The project profile service.</param>
        /// </summary>
        public ProjectProfileController(IProjectProfileService projectProfileService)
        {
            _projectProfileService = projectProfileService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the project profiles.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ProjectProfileModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_projectProfileService.Get());
        }

        /// <summary>
        /// Retrieve the project profiles by unique identifier.
        /// </summary>
        /// <param name="id">The project profiles identifier.</param>
        /// <returns>The project profile.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProjectProfile), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_projectProfileService.GetById(id));
        }

        #endregion

        #region Post

        /// <summary>
        /// Post the add project profile.
        /// </summary>
        /// <param name="projectProfileDto">The project profile data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectComponent), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] ProjectProfileDTO projectProfileDto)
        {
            if (projectProfileDto == null)
                throw new ArgumentNullException(nameof(projectProfileDto));

            return Ok(await _projectProfileService.Add(projectProfileDto));
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update project profile.
        /// </summary>
        /// <param name="projectProfileDto">The project profile  data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProjectComponent), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProjectProfileDTO projectProfileDto)
        {
            if (projectProfileDto == null)
                throw new ArgumentNullException(nameof(projectProfileDto));

            return Ok(await _projectProfileService.Update(projectProfileDto));
        }

        #endregion Put
    }
}
