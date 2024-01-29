using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using FAIS.ApplicationCore.Services;
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
    public class LibraryTypeController : Controller
    {
        #region Variables

        private readonly ILibraryTypeService _libraryTypeService;

        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref=LibraryTypeController"/> class.
        /// <param name="libraryTypeService">The librarytype service.</param>
        /// </summary>
        public LibraryTypeController(ILibraryTypeService libraryTypeService)
        {
            _libraryTypeService = libraryTypeService;
        }

        #endregion Constructor

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PermissionModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_libraryTypeService.Get());
        }
    }
}
