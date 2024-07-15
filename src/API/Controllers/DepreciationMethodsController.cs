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
        /// <param name="service">List the depreciation methods.</param>
        /// </summary>
        public DepreciationMethodsController(IDepreciationMethodsService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// List of depreciation methods.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<DepreciationMethodsModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Get the depreciation methods by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
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
        /// <param name="DTO">The depreciation methods data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(DepreciationMethods), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DepreciationMethodsDTO DTO)
        {
            if (DTO == null)
                throw new ArgumentNullException(nameof(DTO));

            return Ok(await _service.Add(DTO));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update depreciation methods
        /// </summary>
        /// <param name="dto">The depreciation methods data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(DepreciationMethods), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DepreciationMethodsDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.Update(dto));
        }
        #endregion
    }
}  