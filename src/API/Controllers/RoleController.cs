using System.Collections.Generic;
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
    //[Authorize]
    public class RoleController : ControllerBase
    {
        #region Variables

        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// <param name="roleService">The role service.</param>
        /// <param name="userService">The user service.</param>
        /// </summary>
        public RoleController(IRoleService roleService, IUserRoleService userRoleService)
        {
            _roleService = roleService;
            _userRoleService = userRoleService;
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
        /// Get UserRoles by Id
        /// </summary>
        /// <param name="userId"> The user Identifier.</param>
        /// <returns></returns>
        [HttpGet("user-roles/{userId:int}")]
        public IActionResult GetUserRoles(int userId)
        {
            return Ok(_roleService.GetUserRolesById(userId));
        }
        #endregion Get

        #region Post
     

        #endregion Post
    }
}
