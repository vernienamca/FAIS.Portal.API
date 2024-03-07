using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
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
    //[Authorize]
    public class TransLineProfileController : ControllerBase
    {
        #region Variables

        private readonly ITransLineProfileService _transLineProfileService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TransLineProfileController"/> class.
        /// <param name="transLineProfileService">The transmission line profile service.</param>
        /// </summary>
        public TransLineProfileController(ITransLineProfileService transLineProfileService) => _transLineProfileService = transLineProfileService;

        #endregion Constructor

        #region Get

        /// <summary>
        /// Retrieve the list of transmission line profile.
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

        #region Post

        /// <summary>
        /// Posts the create transmission line profile.
        /// </summary>
        /// <param name="transLineProfileDTO">transmission line profile object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(TransLineProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] TransLineProfileDTO transLineProfileDTO)
        {
            if (transLineProfileDTO == null)
                throw new ArgumentNullException(nameof(transLineProfileDTO));

            try
            {
                var result = await _transLineProfileService.Add(transLineProfileDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { errorDescription = ex.Message });
            }
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update transmission line profile.
        /// </summary>
        /// <param name="data">The transmissionline profile data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(TransLineProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] TransLineProfileDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            try
            {
                var result = await _transLineProfileService.Update(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { errorDescription = ex.Message });
            }
        }

        #endregion Put
    }
}
