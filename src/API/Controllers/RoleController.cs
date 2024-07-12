using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Services;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : ControllerBase
    {
        #region Variables

        private readonly IRoleService _roleService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// <param name="roleService">The role service.</param>
        /// </summary>
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
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

        /// <summary>
        /// Posts the create role.
        /// </summary>
        /// <param name="roleDto">The role data object.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] RoleDTO roleDto)
        {
            if (roleDto == null)
                throw new ArgumentNullException(nameof(roleDto));

            return Ok(_roleService.Add(roleDto));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the update role.
        /// </summary>
        /// <param name="roleDto">The role data object.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] RoleDTO roleDto)
        {
            if (roleDto == null)
                throw new ArgumentNullException(nameof(roleDto));

            return Ok(await _roleService.Update(roleDto));
        }

        #endregion Put
    }
}
