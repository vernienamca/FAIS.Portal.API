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
    public class DefinedTableColumnsController : ControllerBase
    {
        #region Variables

        private readonly IDefinedTableColumnsService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedTableColumnsController"/> class.
        /// <param name=service">The defined table columns service.</param>
        /// </summary>
        public DefinedTableColumnsController(IDefinedTableColumnsService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List of defined table columns.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<DefinedTableColumnsModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Gets the defined table columns by unique identifier.
        /// </summary>
        /// <param name="id">The defined table columns unique identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(DefinedTableColumnsModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create defined table columns.
        /// </summary>
        /// <param name="definedTableColumnsDto">The defined table columns data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DefinedTableColumns), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DefinedTableColumnsDTO definedTableColumnsDto)
        {
            if (definedTableColumnsDto == null)
                throw new ArgumentNullException(nameof(definedTableColumnsDto));

            return Ok(await _service.Add(definedTableColumnsDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update defined table columns.
        /// </summary>
        /// <param name="definedTableColumnsDto">The defined tables data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(DefinedTableColumns), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DefinedTableColumnsDTO definedTableColumnsDto)
        {
            if (definedTableColumnsDto == null)
                throw new ArgumentNullException(nameof(definedTableColumnsDto));

            return Ok(await _service.Update(definedTableColumnsDto));
        }

        #endregion
    }
}  