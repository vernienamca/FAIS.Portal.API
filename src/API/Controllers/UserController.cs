using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region Variables

        private readonly IUserService _userService;
        private readonly ILibraryTypeService _libraryTypeService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController(IUserService userService, ILibraryTypeService libraryTypeService)
        {
            _userService = userService;
            _libraryTypeService = libraryTypeService;
        }

        #endregion Constructor

        [HttpGet("[action]")]
        [Authorize]
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
                Position = _libraryTypeService.GetById(entity.PositionId).Name,
                Photo = entity.Photo
            };

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    return BadRequest("UserDTO is null");
                }

                var addedUser = await _userService.Add(userDTO);

                return CreatedAtAction(nameof(GetById), new { id = addedUser.Id }, addedUser);
            }
            catch (Exception ex)
            {
                // Log the exception using Debug.WriteLine for debugging
                Debug.WriteLine($"An error occurred in AddUser action: {ex.Message}");

                // Log the stack trace
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Log inner exception details if available
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception Message: {ex.InnerException.Message}");
                    Debug.WriteLine($"Inner Exception Stack Trace: {ex.InnerException.StackTrace}");
                }

                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("UserDTO is null");
            }

            var result = await _userService.Update(userDTO);

            return Ok(result);
        }
    }
}