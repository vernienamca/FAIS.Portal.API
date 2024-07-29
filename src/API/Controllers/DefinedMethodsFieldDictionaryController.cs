using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Services;
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
    public class DefinedMethodsFieldDictionaryController : ControllerBase
    {
        #region Variables

        private readonly IDefinedMethodsFieldDictionaryService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedMethodsFieldDictionaryController"/> class.
        /// <param name="service">List the defined methods field dictionary .</param>
        /// </summary>
        public DefinedMethodsFieldDictionaryController(IDefinedMethodsFieldDictionaryService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get
        /// <summary>
        /// List of defined methods field dictionary.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<DefinedMethodsFieldDictionaryModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Get the defined methods field dictionary by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(DefinedMethodsFieldDictionaryModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion Get

        #region Post
        /// <summary>
        /// Posts the create defined methods field dictionary.
        /// </summary>
        /// <param name="DTO">The defined methods field dictionary data object.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(DefinedMethodsFieldDictionary), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(DefinedMethodsFieldDictionaryDTO DTO)
        {
            if (DTO == null)
                throw new ArgumentNullException(nameof(DTO));

            return Ok(await _service.Add(DTO));
        }
        #endregion

        #region Put
        /// <summary>
        /// Puts the update defined methods field dictionary
        /// </summary>
        /// <param name="dto">The defined methods field dictionary data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(DefinedMethodsFieldDictionary), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DefinedMethodsFieldDictionaryDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(await _service.Update(dto));
        }
        #endregion
    }
}  