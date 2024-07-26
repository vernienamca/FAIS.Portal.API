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
    public class FieldDictionaryController : ControllerBase
    {
        #region Variables

        private readonly IFieldDictionaryService _service;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldDIctionaryController"/> class.
        /// <param name=service">The field dictionary service.</param>
        /// </summary>
        public FieldDictionaryController(IFieldDictionaryService service) 
        {
            _service = service;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the field dictionaries.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<FieldDictionaryModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        /// <summary>
        /// Get the field dictionary by unique identifier.
        /// </summary>
        /// <param name="id">The field dictionary unique identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FieldDictionaryModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the create field dictionary.
        /// </summary>
        /// <param name="fieldDictionaryDto">The field dictionary data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(FieldDictionary), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(FieldDictionaryDTO fieldDictionaryDto)
        {
            if (fieldDictionaryDto == null)
                throw new ArgumentNullException(nameof(fieldDictionaryDto));

            return Ok(await _service.Add(fieldDictionaryDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update field dictionary.
        /// </summary>
        /// <param name="fieldDictionaryDto">The field dictionary data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(FieldDictionary), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(FieldDictionaryDTO fieldDictionaryDto)
        {
            if (fieldDictionaryDto == null)
                throw new ArgumentNullException(nameof(fieldDictionaryDto));

            return Ok(await _service.Update(fieldDictionaryDto));
        }

        #endregion
    }
}  