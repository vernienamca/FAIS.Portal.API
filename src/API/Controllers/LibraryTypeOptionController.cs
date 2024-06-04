using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class LibraryTypeOptionController : Controller 
    {
        #region Variables

        private readonly ILibraryOptionService _libraryOptionService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryTypeOptionController"/> class.
        /// <param name="libraryOptionService">The library option service.</param>
        /// </summary>
        public LibraryTypeOptionController(ILibraryOptionService libraryOptionService)
        {
            _libraryOptionService = libraryOptionService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the library type options.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<LibraryOptionModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_libraryOptionService.Get());
        }

        /// <summary>
        /// List the library type option values.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("lookups")]
        [ProducesResponseType(typeof(List<LibraryOptionModel>), StatusCodes.Status200OK)]
        public IActionResult GetLookupValues([FromQuery] string[] codes)
        {
            return Ok(_libraryOptionService.GetLookupValues(codes));
        }

        /// <summary>
        /// Gets the library type options by unique identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(LibraryOptionModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_libraryOptionService.GetById(id));
        }

        #endregion

        #region Post

        /// <summary>
        /// Add Library Type Option.
        /// </summary>
        /// <param name="libraryOptionAddDto">The library type option data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(LibraryOptionModel), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] LibraryOptionAddDto libraryOptionAddDto)
        {
            return Ok(_libraryOptionService.Add(libraryOptionAddDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update library type option.
        /// </summary>
        /// <param name="libraryOptionUpdateDto">The library type option data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(LibraryOptionModel), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] LibraryOptionUpdateDto libraryOptionUpdateDto)
        {
            if (libraryOptionUpdateDto == null)
                throw new ArgumentNullException(nameof(libraryOptionUpdateDto));

            return Ok(_libraryOptionService.Update(libraryOptionUpdateDto));
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete Library Type Option by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok(_libraryOptionService.Delete(id));
        }

        #endregion
    }
}
