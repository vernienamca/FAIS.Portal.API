using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
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
    public class ProjectProfileController : ControllerBase
    {
        #region Variables

        private readonly IProjectProfileService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectProfileController"/> class.
        /// <param name="ProjectProfileService">List the project profiles.</param>
        /// </summary>
        public ProjectProfileController(IProjectProfileService projectProfileService)
        {
            _service = projectProfileService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// Retrieve the list of project profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ProjectProfile>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Retrieve a Project Profile by unique identifier.
        /// </summary>
        /// <param name="id">The project profile identifier.</param>
        /// <returns>A project profile.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProjectProfile), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Post the add project profile.
        /// </summary>
        /// <param name="projectProfileDto">The project profile data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectProfileDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] ProjectProfileDTO projectProfileDto)
        {
            if (projectProfileDto == null)
                throw new ArgumentNullException(nameof(projectProfileDto));

            return Ok(await _service.Add(projectProfileDto));
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update project profile
        /// </summary>
        /// <param name="projectProfileDto">The project profile data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProjectProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProjectProfileDTO projectProfileDto)
        {
            if (projectProfileDto == null)
                throw new ArgumentNullException(nameof(projectProfileDto));

            return Ok(await _service.Update(projectProfileDto));
        }

        #endregion Put
    }
}