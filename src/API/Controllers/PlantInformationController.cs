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
        /// Gets the list of plant informations.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PlantInformationModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Gets the plant informaiton by unique identifier.
        /// </summary>
        /// <param name="id">The plant information identifier.</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PlantInformationModel>), StatusCodes.Status200OK)]
        public IActionResult GetById(string id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create plant information.
        /// </summary>
        /// <param name="plantInfoDTO">The plant information data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(PlantInformation), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(AddPlantInformationDTO plantInfoDTO)
        {
            if (plantInfoDTO == null)
                throw new ArgumentNullException(nameof(plantInfoDTO));

            return Ok(await _service.Add(plantInfoDTO));
        }
        #endregion

        #region Put

        /// <summary>
        /// Puts the update plant information.
        /// </summary>
        /// <param name="plantInfoDTO">The plant information data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">command</exception>
        [HttpPut("{code}")]
        [ProducesResponseType(typeof(PlantInformation), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdatePlantInformationDTO plantInfoDTO)
        {
            if (plantInfoDTO == null)
                throw new ArgumentNullException(nameof(plantInfoDTO));

            return Ok(await _service.Update(plantInfoDTO));
        }

        #endregion
    }
}  