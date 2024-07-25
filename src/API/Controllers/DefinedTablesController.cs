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
    public class DefinedTablesController : ControllerBase
    {
        #region Variables

        private readonly IDefinedTablesService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedTablesController"/> class.
        /// <param name="service">List the business process.</param>
        /// </summary>
        public DefinedTablesController(IDefinedTablesService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// Retrieve the list of defined tables.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<DefinedTablesModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Retrieve the defined tables by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(DefinedTablesModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Posts the create defined tables.
        /// </summary>
        /// <param name="DTO">The defined tables data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(DefinedTables), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DefinedTablesDTO DTO)
        {
            if (DTO == null)
                throw new ArgumentNullException(nameof(DTO));

            return Ok(await _service.Add(DTO));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update defined tables
        /// </summary>
        /// <param name="dto">The defined tables data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(DefinedTables), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DefinedTablesDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.Update(dto));
        }
        #endregion
    }
}  