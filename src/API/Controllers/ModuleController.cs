using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
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
        public async Task<IEnumerable<ModuleModel>> Get()
        {
            var data = _moduleService.Get();

            if (data == null)
                return null;

            List<ModuleModel> modules = new List<ModuleModel>();

            foreach (var module in data)
            {
                var createdBy = await _userService.GetById(module.CreatedBy);
                var modifiedBy = await _userService.GetById(module.UpdatedBy.Value);

                var entity = new ModuleModel()
                {
                    Id = module.Id,
                    Name = module.Name,
                    Description = module.Description,
                    Url = module.Url,
                    IsActive = module.IsActive,
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
    }
}