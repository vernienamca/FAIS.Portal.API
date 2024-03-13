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
    //[Authorize]
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

        #region get
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

        #region post
        /// <summary>
        /// Add permission
        /// </summary>
        /// <param name="permission">The permission identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AddPermissionDTO permission)
        {
            return Ok(_permissionService.AddPermission(permission));
        }

        /// <summary>
        /// Update role and permission connected to role
        /// </summary>
        /// <param name="updateRolePermission">The role and permission identifier.</param>
        /// <returns></returns>
        [HttpPut("Role")]
        public IActionResult UpdateRolePermission(UpdateRolePermissionDTO updateRolePermission)
        {
            return Ok(_permissionService.UpdateRoleAddPermission(updateRolePermission));
        }
        #endregion

        #region put
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

        #region delete
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
