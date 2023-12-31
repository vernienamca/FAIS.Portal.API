using System.Collections.Generic;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IEnumerable<RoleModel> Get()
        {
            List<RoleModel> roles = new List<RoleModel>();

            foreach (var role in _roleService.Get())
            {
                var createdBy = _userService.GetById(role.CreatedBy);
                var modifiedBy = _userService.GetById(role.UpdatedBy.Value);

                var entity = new RoleModel()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive == 'Y',
                    StatusDate = role.StatusDate,
                    CreatedBy = string.Format("{0} {1}", createdBy.FirstName, createdBy.LastName),
                    CreatedAt = role.CreatedAt
                };

                if (modifiedBy != null)
                {
                    entity.UpdatedBy = string.Format("{0} {1}", modifiedBy.FirstName, modifiedBy.LastName);
                    entity.UpdatedAt = role.UpdatedAt;
                }

                roles.Add(entity);
            }

            return roles;
        }

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
        {
            return Ok(_roleService.GetById(id));
        }
    }
}