using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleController"/> class.
        /// </summary>
        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<Module> Get()
        {
            return _service.Get();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var entity = await _service.GetById(id);

            return Ok(new { entity });
        }
    }
}