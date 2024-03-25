using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlantInformationController : ControllerBase
    {
        #region Variables

        private readonly IPlantInformationService _plantInformationService;
        
        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PlantInformationController"/> class.
        /// Add mapper for LibraryTypeModel 
        /// <param name="PlantInformationService">The library type service.</param>
        /// </summary>
        public PlantInformationController(IPlantInformationService plantInformationService)
        {
            _plantInformationService = plantInformationService;
        }
        #endregion Constructor

        #region Get

        /// <summary>
        /// Retrive the list the library types.
        /// </summary>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PlantInformationModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_plantInformationService.Get());
        }

        #endregion
    }
}
