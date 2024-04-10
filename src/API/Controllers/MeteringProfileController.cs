using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        #region post

        /// <summary>
        /// Posts the create metering profile.
        /// </summary>
        /// <param name="dto">The metering profile data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MeteringProfile), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] MeteringProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(_service.Add(dto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update metering profile.
        /// </summary>
        /// <param name="dto">The metering profile data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MeteringProfile), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] MeteringProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(_service.Update(dto));
        }

        #endregion
    }
}  