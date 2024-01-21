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
using FAIS.ApplicationCore.Entities.Security;

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
                Photo = entity.Photo
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

        /// <summary>
        /// Gets the list of permissions for the specific user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("settings/{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApplicationCore.Entities.Structure.Settings), StatusCodes.Status200OK)]
        public IActionResult GetSettings(int id)
        {
            return Ok(_settingsService.GetById(id));
        }

        /// <summary>
        /// Gets the user by temporary key.
        /// </summary>
        /// <param name="tempKey">The temporary key.</param>
        /// <returns></returns>
        [HttpGet("tempkey/{tempKey}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByTempKey(string tempKey)
        {
            return Ok(await _userService.GetByTempKey(tempKey));
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
            content = content.Replace("${url}", $"{settings.BaseUrl}/reset-password/{tempKey}");
            content = content.Replace("${baseurl}", $"{settings.BaseUrl}");

            if (_emailService.SendEmail(user.EmailAddress, "Forgot Password", content))
                return Ok(user);

            return Ok();
        }

        /// <summary>
        /// Puts the reset password.
        /// </summary>
        /// <param name="tempKey">The temporary key.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        [HttpPut("reset-password/{tempKey}/{newPassword}")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string tempKey, string newPassword)
        {
            if (string.IsNullOrEmpty(tempKey))
                throw new ArgumentNullException(nameof(tempKey));

            return Ok(await _userService.ResetPassword(tempKey, newPassword));
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
    }
}