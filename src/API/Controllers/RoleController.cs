using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        #region Variables

        private readonly IRoleService _roleService;
        private readonly IRolePermissionService _rolePermissionService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        public RoleController(IRoleService roleService
            , IUserService userService
            , IRolePermissionService rolePermissionService)
        {
            _roleService = roleService;
            _rolePermissionService = rolePermissionService;
        }

        #endregion Constructor

        /// <summary>
        /// Gets the list of roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(RoleModelDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _rolePermissionService.GetRolePermission());
        }
      
        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            return Ok(_roleService.GetById(id));
        }

        /// <summary>
        /// Gets the role by unique identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        [HttpGet("role-permission/{roleId:int}")]
        [ProducesResponseType(typeof(RoleModelDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRolePermissionById(int roleId)
        {
            return Ok(await _rolePermissionService.GetRolePermissionById(roleId));
        }

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        [HttpPut("update-role")]
        [ProducesResponseType(typeof(RoleModelDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateRolePermission([FromBody] RoleModelDTO permissions)
        {
             return Ok(await _rolePermissionService.UpdateRolePermission(permissions));
        }
    }
}