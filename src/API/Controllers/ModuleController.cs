using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleController"/> class.
        /// </summary>
        public ModuleController(IModuleService moduleService, IUserService userService)
        {
            _moduleService = moduleService;
            _userService = userService;
        }

        /// <summary>
        /// Retrieve all modules.
        /// </summary>
        /// <returns>The modules.</returns>
        [HttpGet("[action]")]
        public IEnumerable<ModuleModel> Get()
        {
            List<ModuleModel> modules = new List<ModuleModel>();

            foreach(var module in _moduleService.Get())
            {
                var createdBy = _userService.GetById(module.CreatedBy);
                var modifiedBy = _userService.GetById(module.UpdatedBy.Value);

                var entity = new ModuleModel()
                {
                    Id = module.Id,
                    Name = module.Name,
                    Description = module.Description,
                    Url = module.Url,
                    IsActive = module.IsActive == 'Y',
                    StatusDate = module.StatusDate,
                    CreatedBy = string.Format("{0} {1}", createdBy.FirstName, createdBy.LastName),
                    CreatedAt = module.CreatedAt
                };

                if (modifiedBy != null)
                {
                    entity.UpdatedBy = string.Format("{0} {1}", modifiedBy.FirstName, modifiedBy.LastName);
                    entity.UpdatedAt = module.UpdatedAt;
                }

                modules.Add(entity);
            }

            return modules;
        }

        /// <summary>
        /// Retrieve module filter by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The module.</returns>
        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
        {
            return Ok(_moduleService.GetById(id));
        }

        /// <summary>
        /// Update module.
        /// </summary>
        /// <param name="moduleDTO">The module DTO.</param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateModule([FromBody] ModuleDTO moduleDTO)
        {
            if (moduleDTO == null)
            {
                return BadRequest("ModuleDTO is null");
            }

            var result = await _moduleService.Update(moduleDTO);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            await _moduleService.Delete(id);

            return Ok();
        }
    }
}