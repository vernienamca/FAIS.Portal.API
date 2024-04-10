using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
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
        #endregion Get
    }
}  