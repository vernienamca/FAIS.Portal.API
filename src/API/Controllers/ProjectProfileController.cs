using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
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
    public class ProjectProfileController : ControllerBase
    {
        #region Variables

        private readonly IProjectProfileService service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectProfileController"/> class.
        /// <param name="ProjectProfileService">The project profile service.</param>
        /// </summary>
        public ProjectProfileController(IProjectProfileService projectProfileService)
        {
            service = projectProfileService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List of project profiles.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ProjectProfileModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        /// <summary>
        /// Get project profile by unique identifier.
        /// </summary>
        /// <param name="id">The project profile details.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProjectProfileModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the add project profile.
        /// </summary>
        /// <param name="projectProfileDto">The project profile data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(AddProjectProfileDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] AddProjectProfileDTO projectProfileDto)
        {
            if (projectProfileDto == null)
                throw new ArgumentNullException(nameof(projectProfileDto));

            return Ok(await service.Add(projectProfileDto));
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update project profile.
        /// </summary>
        /// <param name="projectProfileDto">The project profile data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProjectProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProjectProfileDTO projectProfileDto)
        {
            if (projectProfileDto == null)
                throw new ArgumentNullException(nameof(projectProfileDto));

            return Ok(await service.Update(projectProfileDto));
        }

        #endregion Put
    }
}