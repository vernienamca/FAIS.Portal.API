using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FAIS.Portal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RolePermissionController : Controller
    {
        #region Variables

        private readonly IRolePermissionService _rolePermissionService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionController"/> class.
        /// <param name="rolePermissionService">The role service.</param>
        /// <param name="userService">The user service.</param>
        /// </summary>
        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        #endregion Constructor

        #region get
        [HttpGet]
        [ProducesResponseType(typeof(RoleResponseModelDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRolePermissionList()
        {
            return Ok(await _rolePermissionService.GetListRolePermission());
        }
        #endregion

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        [HttpPut("update-role")]
        [ProducesResponseType(typeof(RoleResponseModelDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateRolePermission([FromBody] RoleRequestModelDTO permissions)
        {
            await _rolePermissionService.UpdateRolePermission(permissions);
            return Ok();
        }
    }
}
