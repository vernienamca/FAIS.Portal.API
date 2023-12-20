using System;
using System.Collections.Generic;
using FAIS.ApplicationCore.DTOs;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Portal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FAIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILibraryTypeService _libraryTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController(IUserService userService, ILibraryTypeService libraryTypeService)
        {
            _userService = userService;
            _libraryTypeService = libraryTypeService;
        }

       



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

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery] int id)
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



    }
}