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
using AutoMapper;

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
        private readonly IMapper _mapper;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryTypeController"/> class.
        /// Add mapper for LibraryTypeModel 
        /// <param name="libraryTypeService">The library type service.</param>
        /// </summary>
        public LibraryTypeController(ILibraryTypeService libraryTypeService, IUserService userService, IMapper mapper)
        {
            _libraryTypeService = libraryTypeService;
            _userService = userService;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// Gets the list of library types.
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
            var data = _libraryTypeService.GetById(id);
            var createdBy = await _userService.GetById(data.Result.CreatedBy);
            var libraryTypeMapper = _mapper.Map<LibraryTypeModel>(data.Result);
            libraryTypeMapper.CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}";

            if (data.Result.UpdatedBy.HasValue)
            {
                var updatedBy = await _userService.GetById(data.Result.UpdatedBy.Value);
                libraryTypeMapper.UpdatedBy = $"{updatedBy.FirstName} {updatedBy.LastName}";
                libraryTypeMapper.UpdatedAt = data.Result.UpdatedAt;
            }

            return Ok(libraryTypeMapper);
        }

        #endregion

        #region Post

        /// <summary>
        /// Posts the create library type.
        /// </summary>
        /// <param name="dto">The library type data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(LibraryType), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] AddLibraryTypeDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if ( await _libraryTypeService.GetByCode(dto.Code) != null)
            {
                return Ok(new { errorDescription = "Code already in use/ Duplicate code detected" });
            }
            return Ok(_libraryTypeService.Add(dto));
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update library type.
        /// </summary>
        /// <param name="dto">The library type data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(LibraryType), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] UpdateLibraryTypeDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var lib = _libraryTypeService.GetById(dto.Id);
            if (dto.IsActive != lib.Result.IsActive)
            {
                lib.Result.IsActive = dto.IsActive;
                dto.StatusDate = DateTime.Now;
            }

            return Ok(_libraryTypeService.Update(dto));
        }
        
        #endregion
    }
}