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

        #region Post
        /// <summary>
        /// Posts the create transmission line profile.
        /// </summary>
        /// <param name="dto">The transmission line profile data object.</param>
        /// <returns></returns>
        [HttpPost("transmission-line-profile")]
        [ProducesResponseType(typeof(TransmissionLineProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCreateInterpolation(AddTransmissionLineProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.Add(dto));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update transmission line profile
        /// </summary>
        /// <param name="dto">The transmission line profile data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(TransmissionLineProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateTransmissionLineProfileDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var transProfile = await _service.GetById(dto.Id);
            if (dto.IsActive != transProfile.IsActive)
            {
                transProfile.IsActive = dto.IsActive;
                dto.StatusDate = DateTime.Now;
            }

            return Ok(_service.Update(dto));
        }
        #endregion
    }
}  