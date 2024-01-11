using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly IRolePermissionService _rolePermissionService;
        

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        public RoleController(IRoleService roleService, IUserService userService, IRolePermissionService rolePermissionService)
        {
            _roleService = roleService;
            _userService = userService;
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _rolePermissionService.GetRolePermission());
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(_roleService.GetById(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRolePermissionById([FromQuery]int id)
        {
            return Ok(await _rolePermissionService.GetRolePermissionById(id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRolePermission([FromBody] RoleModelDTO permissions)
        {
             return Ok(await _rolePermissionService.UpdateRolePermission(permissions));
        }
    }
}