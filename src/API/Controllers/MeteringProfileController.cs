using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Services;
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
    public class MeteringProfileController : ControllerBase
    {
        #region Variables

        private readonly IMeteringProfileService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MeteringProfileController"/> class.
        /// <param name="meteringProfileService">List the metering profiles.</param>
        /// </summary>
        public MeteringProfileController(IMeteringProfileService meteringProfileService) 
        {
            _service = meteringProfileService;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of metering profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<MeteringProfile>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }
        #endregion Get
    }
}  