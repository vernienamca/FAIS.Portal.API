using FAIS.ApplicationCore.DTOs.Structure;
using FAIS.ApplicationCore.Interfaces.Service;
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
    public class LibraryTypeOptionController : Controller
    {
        #region Variables

        private readonly ILibraryOptionService _libraryOptionTypeService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleController"/> class.
        /// <param name="libraryOptionTypeService">The module service.</param>
        /// </summary>
        public LibraryTypeOptionController(ILibraryOptionService libraryOptionTypeService)
        {
            _libraryOptionTypeService = libraryOptionTypeService;
        }

        #endregion Constructor

        #region get
        /// <summary>
        /// List the LibraryTypeOption.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<LibraryOptionModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_libraryOptionTypeService.Get());
        }

        /// <summary>
        /// List the LibraryTypeOption.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{id:int}")]
        [ProducesResponseType(typeof(LibraryOptionModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_libraryOptionTypeService.GetById(id));
        }
        #endregion

        #region post
        /// <summary>
        /// Add LibraryTypeOption.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] LibraryOptionAddDto libraryOptionAddDto)
        {
            return Ok(_libraryOptionTypeService.Add(libraryOptionAddDto));
        }
        #endregion

        #region put
        /// <summary>
        /// Update LibraryTypeOption by id.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] LibraryOptionUpdateDto libraryOptionUpdateDto)
        {
            return Ok(_libraryOptionTypeService.Update(libraryOptionUpdateDto));
        }
        #endregion

        #region delete
        /// <summary>
        /// Delete LibraryTypeOption by id.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            return Ok(_libraryOptionTypeService.Delete(id));
        }
        #endregion
    }
}
