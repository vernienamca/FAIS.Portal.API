using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
        {
            return Ok(_moduleService.GetById(id));
        }
    }
}