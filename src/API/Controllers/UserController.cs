using System;
using System.Collections.Generic;
using FAIS.ApplicationCore.DTOs;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FAIS.ApplicationCore.Models;
using System.IO;

namespace FAIS.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        #region Variables

        private readonly IUserService _userService;
        private readonly ILibraryTypeService _libraryTypeService;
        private readonly IEmailService _emailService;
        private readonly ISettingsService _settingsService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// <param name="userService">The user service.</param>
        /// <param name="libraryTypeService">The library type service.</param>
        /// <param name="emailService">The email service.</param>
        /// <param name="settingsService">The settings service.</param>
        /// </summary>
        public UserController(IUserService userService
            , ILibraryTypeService libraryTypeService
            , IEmailService emailService
            , ISettingsService settingsService)
        {
            _userService = userService;
            _libraryTypeService = libraryTypeService;
            _emailService = emailService;
            _settingsService = settingsService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// List the users.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserModel>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_userService.Get());
        }

        /// <summary>
        /// Gets the user by unique identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _userService.GetById(id);
           
            var user = new UserModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Position = _libraryTypeService.GetById(entity.PositionId).Name,
                Division = entity.DivisionId.HasValue ? _libraryTypeService.GetById(entity.DivisionId.Value)?.Name : null,
                TAFGs = _libraryTypeService.GetLibraryCodesById(entity.Id, "TAFG"),
                OUFG = _libraryTypeService.GetLibraryCodesById(entity.Id, "OUFG")[0],
                EmployeeNumber = entity.EmployeeNumber,
                DateExpired = entity.DateExpired,
                StatusDate = entity.StatusDate,
                UserName = entity.UserName,
                MobileNumber = entity.MobileNumber,
                Status = entity.StatusCode,
                EmailAddress = entity.EmailAddress,
                Photo = entity.Photo,
            };

            return Ok(user);
        }

        /// <summary>
        /// Gets the list of permissions for the specific user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("permissions/{userId:int}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<PermissionModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPermissions(int userId)
        {
            var permissions = await _userService.GetPermissions(userId);

            return Ok(permissions);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastLoginDate(int userId)
        {
            var lastLoginDate = await _userService.GetLastLoginDate(userId);
            return Ok(lastLoginDate.Value);
        }


        #endregion Get

        #region Post

        /// <summary>
        /// Posts the forgot password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpPost("forgot-password/{emailAddress}")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string emailAddress)
        {
            var user = await _userService.GetByEmailAddress(emailAddress);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            string htmlTemplatePath = Path.Combine($"{Environment.CurrentDirectory}\\Email Templates", "ForgotPassword.html");

            if (!System.IO.File.Exists(htmlTemplatePath))
                throw new FileNotFoundException(nameof(htmlTemplatePath));

            string content = System.IO.File.ReadAllText(htmlTemplatePath);

            var settings = _settingsService.GetById(1);

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            string tempKey = await _userService.SetTemporaryKey(user.Id);

            content = content.Replace("${firstname}", user.FirstName);
            content = content.Replace("${supportemail}", settings.EmailAddress);
            content = content.Replace("${url}", $"{settings.BaseUrl}/reset-password/${tempKey}");
            content = content.Replace("${baseurl}", $"{settings.BaseUrl}");

            if (_emailService.SendEmail(user.EmailAddress, "Forgot Password", content))
                return Ok(user);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO));

            var addedUser = await _userService.Add(userDTO);

            return CreatedAtAction(nameof(GetById), new { id = addedUser.Id }, addedUser);
        }

        #endregion Post

        #region Put
        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (id <= 0 || userDTO == null)
            {
                return BadRequest("Invalid input");
            }
            var updatedUser = await _userService.Edit(id, userDTO);
            return Ok(updatedUser);
        }
        #endregion Put
    }
}