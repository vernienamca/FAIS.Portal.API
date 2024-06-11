using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FAIS.Portal.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : Controller
    {
        #region Variables

        private readonly IPermissionService _permissionService;

        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionController"/> class.
        /// <param name="permissionService">The notification service.</param>
        /// </summary>
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PermissionModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_permissionService.Get());
        }

        /// <summary>
        /// List the user permissions by module identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="id">The moduleId identifier.</param>
        /// <returns></returns>
        [HttpGet("{userId:int}/{moduleId:int}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PermissionModel>), StatusCodes.Status200OK)]
        public IActionResult GetPermissions(int userId, int moduleId)
        {
            return Ok(_permissionService.GetPermissions(userId, moduleId));
        }

        /// <summary>
        /// Gets the permission by unique identifier.
        /// </summary>
        /// <param name="id">The permission identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_permissionService.GetListPermissionByRoleId(id));
        }

        /// <summary>
        /// Gets the role and permission list by unique identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        [HttpGet("Role/{roleId:int}")]
        public IActionResult GetPermissionByRoleId(int roleId)
        {
            return Ok(_permissionService.GetRolePermissionListByRoleId(roleId));
        }

        #endregion

        #region Post

        /// <summary>
        /// Posts the adding of permission.
        /// </summary>
        /// <param name="permission">The permission data object.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AddPermissionDTO permission)
        {
            return Ok(_permissionService.AddPermission(permission));
        }

        #endregion

        #region Put

        /// <summary>
        /// Puts the updating of role permissions.
        /// </summary>
        /// <param name="updateRolePermission">The role permission data object.</param>
        /// <returns></returns>
        [HttpPut("role")]
        public IActionResult UpdateRolePermission(UpdateRolePermissionDTO updateRolePermission)
        {
            return Ok(_permissionService.UpdateRoleAddPermission(updateRolePermission));
        }

        /// <summary>
        /// Update permission
        /// </summary>
        /// <param name="permission">permission identifier.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(PermissionDTO permission)
        {
            return Ok(_permissionService.UpdatePermission(permission));
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete permission
        /// </summary>
        /// <param name="id">permission identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok(_permissionService.DeletePermission(id));
        }

        #endregion
    }
}
