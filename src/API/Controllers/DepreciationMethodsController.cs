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
    public class DepreciationMethodsController : ControllerBase
    {
        #region Variables

        private readonly IDepreciationMethodsService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DepreciationMethodsController"/> class.
        /// <param name=service">The depreciation methods service.</param>
        /// </summary>
        public DepreciationMethodsController(IDepreciationMethodsService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the depreciation methods.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<DepreciationMethodsModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Gets the depreciation methods by unique identifier.
        /// </summary>
        /// <param name="id">The depreciation methods unique identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(DepreciationMethodsModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create depreciation methods.
        /// </summary>
        /// <param name="depreciationMethodsDto">The depreciation methods data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DepreciationMethods), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DepreciationMethodsDTO depreciationMethodsDto)
        {
            if (depreciationMethodsDto == null)
                throw new ArgumentNullException(nameof(depreciationMethodsDto));

            return Ok(await _service.Add(depreciationMethodsDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update depreciation methods.
        /// </summary>
        /// <param name="depreciationMethodsDto">The depreciation methods data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(DepreciationMethods), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DepreciationMethodsDTO depreciationMethodsDto)
        {
            if (depreciationMethodsDto == null)
                throw new ArgumentNullException(nameof(depreciationMethodsDto));

            return Ok(await _service.Update(depreciationMethodsDto));
        }

        #endregion
    }
}  