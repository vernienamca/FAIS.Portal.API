using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Services;
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
    //[Authorize]
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
        /// Retrieve the list of cost centers.
        /// </summary>
        /// <returns>List of cost centers.</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CostCenterModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_costCenterService.Get());
        }

        /// <summary>
        /// Retrieve the cost center by unique identifier.
        /// </summary>
        /// <param name="id">The cost center identifier.</param>
        /// <returns>The cost center.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CostCenter), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(_costCenterService.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create cost center.
        /// </summary>
        /// <param name="costCenterDTO">cost centere object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(CostCenter), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] CostCenterDTO costCenterDTO)
        {
            if (costCenterDTO == null)
                throw new ArgumentNullException(nameof(costCenterDTO));

            return Ok(await _costCenterService.Add(costCenterDTO));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update cost center.
        /// </summary>
        /// <param name="data">The cost center data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(CostCenter), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CostCenterDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Ok(await _costCenterService.Update(data));
        }

        #endregion Put
    }
}
