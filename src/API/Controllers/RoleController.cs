using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
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
        /// <param name="roleService">The role service.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="rolePermissionService">The role with permission service.</param>
        /// </summary>
        public RoleController(IRoleService roleService, IRolePermissionService rolePermissionService)
        {
            _roleService = roleService;
            _rolePermissionService= rolePermissionService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<RoleModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_roleService.Get());
        }

        /// <summary>
        /// Gets the role by unique identifier.
        /// </summary>
        /// <param name="id">The role identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_roleService.GetById(id));
        }

        /// <summary>
        /// Gets the role by unique identifier.
        /// </summary>
        /// <param name="id">The role identifier.</param>
        /// <returns></returns>
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetRolePermissionById(int id)
        {
            return Ok(await _rolePermissionService.GetRolePermissionById(id));
        }
        #endregion Get
    }
}