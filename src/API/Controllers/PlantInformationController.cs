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
    public class PlantInformationController : ControllerBase
    {
        #region Variables

        private readonly IPlantInformationService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PlantInformationController"/> class.
        /// <param name="service">List the plant information.</param>
        /// </summary>
        public PlantInformationController(IPlantInformationService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of plant information.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PlantInformationModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Retrieve the plant information by code
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PlantInformationModel>), StatusCodes.Status200OK)]
        public IActionResult GetByCode(string code)
        {
            return Ok(_service.GetByCode(code));
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Posts the create plant information.
        /// </summary>
        /// <param name="dto">The plant information data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(PlantInformation), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(AddPlantInformationDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var isExists = _service.GetByCode(dto.PlantCode);
            if (isExists != null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.Add(dto));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update plant information
        /// </summary>
        /// <param name="dto">The plant information data object.</param>
        /// <returns></returns>
        [HttpPut("{code}")]
        [ProducesResponseType(typeof(PlantInformation), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdatePlantInformationDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var pi = _service.GetByCode(dto.PlantCode);
            if (dto.IsActive != pi.IsActive)
            {
                pi.IsActive = dto.IsActive;
                dto.StatusDate = DateTime.Now;
            }

            return Ok(_service.Update(dto));
        }
        #endregion
    }
}  