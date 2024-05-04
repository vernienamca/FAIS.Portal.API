using FAIS.ApplicationCore.Interfaces.Service;
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
    public class TransmissionLineProfileController : ControllerBase
    {
        #region Variables

        private readonly ITransmissionLineProfileService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TransmissionLineProfileController"/> class.
        /// <param name="transProfileService">List the transmission line profiles.</param>
        /// </summary>
        public TransmissionLineProfileController(ITransmissionLineProfileService transProfileService) 
        {
            _service = transProfileService;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of transmission line profile.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<TransmissionLineProfileModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Retrieve the transmission line profile by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(TransmissionLineProfileModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion Get
    }
}  