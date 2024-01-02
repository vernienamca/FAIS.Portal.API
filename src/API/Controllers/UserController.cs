using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        #region Variables

        private readonly IUserService _userService;
        private readonly ILibraryTypeService _libraryTypeService;
        private readonly IRoleService _roleService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController(IUserService userService, ILibraryTypeService libraryTypeService, IRoleService roleService)
        {
            _userService = userService;
            _libraryTypeService = libraryTypeService;
            _roleService = roleService;
        }

        #endregion Constructor

        [HttpGet("[action]")]
        public IEnumerable<UserModel> Get()
        {
            List<UserModel> users = new List<UserModel>();

            foreach (var user in _userService.Get())
            {
                var createdBy = _userService.GetById(user.CreatedBy);
                var modifiedBy = _userService.GetById(user.UpdatedBy.Value);

                var entity = new UserModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmployeeNumber = user.EmployeeNumber,
                    UserName = user.UserName,
                    Position = _libraryTypeService.GetById(user.PositionId).Name,
                    EmailAddress = user.EmailAddress,
                    MobileNumber = user.MobileNumber,
                    Photo = user.Photo,
                    StatusCode = user.StatusCode,
                    StatusDate = user.StatusDate,
                    DateExpired = user.DateExpired,
                    CreatedBy = string.Format("{0} {1}", createdBy.FirstName, createdBy.LastName),
                    CreatedAt = user.CreatedAt
                };

                var division = _libraryTypeService.GetById(user.DivisionId.Value);

                if (division != null)
                    entity.Division = _libraryTypeService.GetById(user.DivisionId.Value).Name;
                    
                if (modifiedBy != null)
                {
                    entity.UpdatedBy = string.Format("{0} {1}", modifiedBy.FirstName, modifiedBy.LastName);
                    entity.UpdatedAt = user.UpdatedAt;
                }

                users.Add(entity);
            }

            return users;
        }

        /// <summary>
        /// Gets the list of permissions for the specific user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("permissions/{userId:int}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PermissionModel>), StatusCodes.Status200OK)]
        public IActionResult GetPermissions(int userId)
        {
            var permissions = _userService.GetPermissions(userId).ToList();

            return Ok(permissions);
        }

        /// <summary>
        /// Gets the user by unique identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var entity = _userService.GetById(id);
 
            var user = new UserModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                EmployeeNumber = entity.EmployeeNumber,
                UserName = entity.UserName,
                MiddleName = entity.MiddleName,
                EmailAddress = entity.EmailAddress,
                MobileNumber = entity.MobileNumber,
                StatusDate = entity.StatusDate,
                DateExpired = entity.DateExpired,
                StatusCode = entity.StatusCode,
                Position = _libraryTypeService.GetById(entity.PositionId).Name,
                Division = _libraryTypeService.GetById(Convert.ToDecimal(entity.DivisionId)).Name,
                OupFgId = entity.OupFgId,
                Photo = entity.Photo
        
            };

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("UserDTO is null");
            }

            var addedUser = await _userService.Add(userDTO);
     
            return CreatedAtAction(nameof(GetById), new { id = addedUser.Id }, addedUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryCode"></param>
        /// <returns></returns>
        [HttpGet("GetLibraryNamesByCode/{libraryCode}")]
        public IActionResult GetLibraryNamesByCode(string libraryCode)
        {
            var libraryNames = _libraryTypeService.GetLibraryNamesByCode(libraryCode);
            return Ok(libraryNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateUser(decimal id, [FromBody] UserDTO userDTO)
        {
            if (id <= 0 || userDTO == null)
            {
                return BadRequest("Invalid input");
            }
            var updatedUser = await _userService.Edit(id, userDTO);
            return Ok(updatedUser);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastUserId()
        {
            var lastUserId = await _userService.GetLastUserId();
            return Ok(lastUserId);
        }
    }
}