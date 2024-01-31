using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ModuleController : ControllerBase
    {
        #region Variables

        private readonly IModuleService _moduleService;
        private readonly IUserService _userService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleController"/> class.
        /// <param name="moduleService">The module service.</param>
        /// <param name="userService">The user service.</param>
        /// </summary>
        public ModuleController(IModuleService moduleService
            , IUserService userService)
        {
            _moduleService = moduleService;
            _userService = userService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the modules.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ModuleModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_moduleService.Get());
        }

        /// <summary>
        /// Gets the module by unique identifier.
        /// </summary>
        /// <param name="id">The module identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Module), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = _moduleService.GetById(id);
            var createdBy = await _userService.GetById(entity.CreatedBy);

            var module = new ModuleModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Url = entity.Url,
                GroupName = entity.GroupName,
                Icon = entity.Icon,
                IsActive = entity.IsActive,
                CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedAt = entity.CreatedAt
            };

            if (entity.UpdatedBy != null)
            {
                module.UpdatedBy = $"{createdBy.FirstName} {createdBy.LastName}";
                module.UpdatedAt = entity.UpdatedAt;
            }

            return Ok(module);
        }

        #endregion Get

        #region Put

        /// <summary>
        /// Puts the update module.
        /// </summary>
        /// <param name="data">The module data object.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ModuleDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Ok(await _moduleService.Update(data));
        }

        #endregion Put
    }
}