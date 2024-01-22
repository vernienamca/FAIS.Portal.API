using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetById(int id)
        {
            return Ok(_moduleService.GetById(id));
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Update module.
        /// </summary>
        /// <param name="moduleDTO">The module DTO.</param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateModule([FromBody] ModuleDTO moduleDTO)
        {
            var result = await _moduleService.Update(moduleDTO);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            await _moduleService.Delete(id);

            return Ok();
        }

        #endregion
    }
}