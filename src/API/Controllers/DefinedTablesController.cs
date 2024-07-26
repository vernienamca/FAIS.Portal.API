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
        /// <param name="service">The defined tables service.</param>
        /// </summary>
        public DefinedTablesController(IDefinedTablesService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the defined tables.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<DefinedTablesModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Get the defined methods field dictionary by unique identifier.
        /// </summary>
        /// <param name="id">The defined methods field dictionary unique identifier.</par
        /// <returns></returns>
        [HttpGet("{id:int}")]
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
        /// <param name="definedTablesDto">The defined tables data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DefinedTables), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DefinedTablesDTO definedTablesDto)
        {
            if (definedTablesDto == null)
                throw new ArgumentNullException(nameof(definedTablesDto));

            return Ok(await _service.Add(definedTablesDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update defined tables.
        /// </summary>
        /// <param name="definedTablesDto">The defined tables data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(DefinedTables), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DefinedTablesDTO definedTablesDto)
        {
            if (definedTablesDto == null)
                throw new ArgumentNullException(nameof(definedTablesDto));

            return Ok(await _service.Update(definedTablesDto));
        }

        #endregion
    }
}  