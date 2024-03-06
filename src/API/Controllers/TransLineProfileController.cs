using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class TransLineProfileController : ControllerBase
    {
        #region Variables

        private readonly ITransLineProfileService _transLineProfileService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TransLineProfileController"/> class.
        /// <param name="transLineProfileService">The cost center service.</param>
        /// </summary>
        public TransLineProfileController(ITransLineProfileService transLineProfileService) => _transLineProfileService = transLineProfileService;

        #endregion Constructor

        #region Get

        /// <summary>
        /// Retrieve the list of cost centers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<TransLineProfileModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_transLineProfileService.Get());
        }

        /// <summary>
        /// Retrieve the transmission line profile by unique identifier.
        /// </summary>
        /// <param name="id">The transmission line profile identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TransLineProfile), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_transLineProfileService.GetById(id));
        }

        #endregion Get
    }
}
