using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        /// <summary>
        /// Gets the role by unique identifier.
        /// </summary>
        /// <param name="id">The role identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_permissionService.GetListPermissionByRoleId(id));
        }

        [HttpGet("role/{roleId:int}")]
        public IActionResult GetByRoleId(int roleId)
        {
            return Ok(_permissionService.GetRolePermissionListByRoleId(roleId));
        }
    }
}
