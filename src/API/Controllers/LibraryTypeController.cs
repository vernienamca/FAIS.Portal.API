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
            var data = _libraryTypeService.GetById(id);
            var createdBy = await _userService.GetById(data.CreatedBy);
            var libraryTypeMapper = _mapper.Map<LibraryTypeModel>(data);
            libraryTypeMapper.CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}";

            if (data.UpdatedBy.HasValue)
            {
                var updatedBy = await _userService.GetById(data.UpdatedBy.Value);
                libraryTypeMapper.UpdatedBy = $"{updatedBy.FirstName} {updatedBy.LastName}";
                libraryTypeMapper.UpdatedAt = data.UpdatedAt;
            }

            return Ok(libraryTypeMapper);
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
        public IActionResult Add([FromBody] AddLibraryTypeDTO dto)
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
        [HttpPut]
        [ProducesResponseType(typeof(LibraryType), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] LibraryTypeDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return Ok(_libraryTypeService.Update(dto));
        }
        
        #endregion
    }
}