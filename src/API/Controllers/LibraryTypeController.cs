using System.Collections.Generic;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Models;
using System;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LibraryTypeController : ControllerBase
    {
        #region Variables

        private readonly ILibraryTypeService _libraryTypeService;
        private readonly IUserService _userService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryTypeController"/> class.
        /// <param name="libraryTypeService">The library type service.</param>
        /// </summary>
        public LibraryTypeController(ILibraryTypeService libraryTypeService, IUserService userService)
        {
            _libraryTypeService = libraryTypeService;
            _userService = userService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// Retrive the list the library types.
        /// </summary>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<LibraryTypeModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_libraryTypeService.Get());
        }

        /// <summary>
        /// Gets the library type by unique identifier.
        /// </summary>
        /// <param name="id">The library type identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(LibraryType), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = _libraryTypeService.GetById(id);
            var createdBy = await _userService.GetById(entity.CreatedBy);

            var lib = new LibraryTypeModel()
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Description = entity.Description,
                IsActive = entity.IsActive,
                StatusDate = entity.StatusDate,
                CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedAt = entity.CreatedAt
            };

            if (entity.UpdatedBy != null)
            {
                lib.UpdatedBy = $"{createdBy.FirstName} {createdBy.LastName}";
                lib.UpdatedAt = entity.UpdatedAt;
            }

            return Ok(lib);
        }

        #endregion

        #region post

        /// <summary>
        /// Posts the create library type.
        /// </summary>
        /// <param name="dto">The library type data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(LibraryType), StatusCodes.Status200OK)]
        public IActionResult Add(AddLibraryTypeDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(_libraryTypeService.Add(dto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update library type.
        /// </summary>
        /// <param name="dto">The library type data object.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(LibraryType), StatusCodes.Status200OK)]
        public IActionResult Update(LibraryTypeDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(_libraryTypeService.Update(dto));
        }
        
        #endregion
    }
}