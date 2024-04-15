using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Services;
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
    public class CostCenterController : ControllerBase
    {
        #region Variables

        private readonly ICostCenterService _costCenterService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CostCenterController"/> class.
        /// <param name="costCenterService">The cost center service.</param>
        /// </summary>
        public CostCenterController(ICostCenterService costCenterService) => _costCenterService = costCenterService;

        #endregion Constructor

        #region Get

        /// <summary>
        /// Gets the list of cost centers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CostCenterModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_costCenterService.Get());
        }

        #endregion Get
    }
}
