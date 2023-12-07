using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<Role> Get()
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