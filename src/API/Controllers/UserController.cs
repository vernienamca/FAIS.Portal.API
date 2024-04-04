using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IUserRoleService _userRoleService;
        private readonly ILibraryTypeRepository _ILibraryTypeRepository;
        private readonly IRoleService _roleService;
        private readonly IConfiguration _configuration;

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
            , ISettingsService settingsService
            , IUserRoleService userRoleService
            , ILibraryTypeRepository libraryTypeRepository
            , IRoleService roleService
            , IConfiguration configuration)
        {
            _userService = userService;
            _libraryTypeService = libraryTypeService;
            _emailService = emailService;
            _settingsService = settingsService;
            _userRoleService = userRoleService;
            _ILibraryTypeRepository = libraryTypeRepository;
            _roleService = roleService;
            _configuration = configuration;
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
            var createdBy = await _userService.GetById(entity.CreatedBy);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var user = new UserModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Position = entity.PositionId.ToString(),
                PositionDescription = _libraryTypeService.GetById(entity.PositionId)?.Name,
                Division = entity.DivisionId.HasValue ? entity.DivisionId.ToString() : string.Empty,
                EmployeeNumber = entity.EmployeeNumber,
                DateExpired = entity.DateExpired,
                StatusDate = entity.StatusDate,
                UserName = entity.UserName,
                MobileNumber = entity.MobileNumber,
                Status = entity.StatusCode,
                EmailAddress = entity.EmailAddress,
                TAFGs = _libraryTypeService.GetLibraryCodesById(entity.Id, "TAFG"),
                OUFG = entity.OupFgId.HasValue ? entity.OupFgId.Value.ToString() : string.Empty,
                LastLoginDate = _userService.GetLastLoginDate(entity.Id).Result,
                Photo = entity.Photo,
                Password = EncryptionHelper.HashPassword(entity.Password),
                CreatedBy = $"{createdBy.FirstName} {createdBy.LastName}",
                CreatedAt = entity.CreatedAt
            };

            if (entity.UpdatedAt != null)
            {
                var updatedBy = await _userService.GetById(entity.UpdatedBy.Value);

                user.UpdatedBy = $"{updatedBy.FirstName} {updatedBy.LastName}";
                user.UpdatedAt = entity.UpdatedAt;
            }

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
        /// Gets the list of roles for the specific user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet("roles/{userId:int}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserRoleModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var userRoles = await _userService.GetUserRoles(userId);

            return Ok(userRoles);
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
        [ProducesResponseType(typeof(ApplicationCore.Entities.Security.User), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByTempKey(string tempKey)
        {
            return Ok(await _userService.GetByTempKey(tempKey));
        }

        /// <summary>
        /// Gets the generated password based on criteria.
        /// </summary>
        /// <returns></returns>
        [HttpGet("generate")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetGeneratedPassword()
        {
            return Ok(_userService.GeneratePassword());
        }

        #endregion Get

        #region Post

        /// <summary>
        /// Posts the forgot password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">command</exception>
        [HttpPost("forgot-password/{emailAddress}")]
        [AllowAnonymous]
        public async Task<IActionResult> PostForgotPassword(string emailAddress)
        {
            var user = await _userService.GetByEmailAddress(emailAddress);

            if (user == null)
                return Ok("Invalid username or password combination. Please try again.");

            string htmlTemplatePath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetSection("EmailTemplatePath")["ForgotPassword"];

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
        /// Posts the create user.
        /// </summary>
        /// <param name="userDTO">The user data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">command</exception>
        [HttpPost]
        public async Task<IActionResult> PostCreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO));

            if (!string.IsNullOrEmpty(userDTO.Photo))
            {
                string photoPath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AssetsPath")["PhotoPath"];
                byte[] imageBytes = Convert.FromBase64String(userDTO.Photo);
                string fileName = $"{Guid.NewGuid()}.png";

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    image.Save(Path.Combine(photoPath, fileName), ImageFormat.Png);

                    userDTO.Photo = fileName;
                }
            }
            else
                userDTO.Photo = "default.png";

            string generatedPassword = _userService.GeneratePassword();

            userDTO.Password = EncryptionHelper.HashPassword(generatedPassword);
            userDTO.CreatedAt = DateTime.Now;

            var user = await _userService.Add(userDTO);

            if (userDTO.TAFG.Count > 0)
                _userService.SetTAFGs(user.Id, userDTO.TAFG);

            string htmlTemplatePath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetSection("EmailTemplatePath")["UserCredential"];

            if (!System.IO.File.Exists(htmlTemplatePath))
                throw new FileNotFoundException(nameof(htmlTemplatePath));

            string content = System.IO.File.ReadAllText(htmlTemplatePath);

            var settings = _settingsService.GetById(1);

            content = content.Replace("${firstname}", user.FirstName);
            content = content.Replace("${username}", user.UserName);
            content = content.Replace("${password}", generatedPassword);
            content = content.Replace("${baseurl}", settings.BaseUrl);

            _emailService.SendEmail(user.EmailAddress, "FAIS Login Credential", content);

            return Ok(user);
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Puts the update user.                                                                                                                                                                                                                                                                      
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="isMyProfile">The is my profile flag.</param>
        /// <param name="userDTO">The user data object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">command</exception>
        [HttpPut("{id:int}/{isMyProfile}")]
        public async Task<IActionResult> PutUpdateUser(int id, bool isMyProfile, [FromBody] UserDTO userDTO)
        {
            var user = await _userService.GetById(id);

            user.LastName = userDTO.LastName;
            user.MobileNumber = userDTO.MobileNumber;

            if (!isMyProfile)
            {
                user.EmployeeNumber = userDTO.EmployeeNumber;
                user.PositionId = int.Parse(userDTO.Position);
                user.FirstName = userDTO.FirstName;
                user.EmailAddress = userDTO.EmailAddress;

                if (userDTO.TAFG.Count > 0)
                    _userService.SetTAFGs(user.Id, userDTO.TAFG);

                if (!string.IsNullOrEmpty(userDTO.OupFG))
                    user.OupFgId = int.Parse(userDTO.OupFG);

                if (!string.IsNullOrEmpty(userDTO.Division))
                    user.DivisionId = int.Parse(userDTO.Division);

                if (int.Parse(userDTO.AccountStatus) != user.StatusCode)
                {
                    user.StatusCode = int.Parse(userDTO.AccountStatus);
                    user.StatusDate = DateTime.Now;
                }

                user.DateExpired = userDTO.AccountExpiration;

                if (!string.IsNullOrEmpty(userDTO.Photo))
                {
                    string photoPath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AssetsPath")["PhotoPath"];
                    byte[] imageBytes = Convert.FromBase64String(userDTO.Photo);
                    string fileName = $"{Guid.NewGuid()}.png";

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        image.Save(Path.Combine(photoPath, fileName), ImageFormat.Png);

                        user.Photo = fileName;
                    }
                }

                if (userDTO.UserRoles.Count > 0)
                    _userService.SetUserRoles(user.Id, userDTO.UserRoles);
            }

            user.UpdatedBy = userDTO.UpdatedBy;
            user.UpdatedAt = DateTime.Now;

            return Ok(await _userService.Update(user));
        }

        /// <summary>
        /// Puts the reset password.
        /// </summary>
        /// <param name="tempKey">The temporary key.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        [HttpPut("reset-password/{tempKey}/{newPassword}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutResetPassword(string tempKey, string newPassword)
        {
            if (string.IsNullOrEmpty(tempKey))
                throw new ArgumentNullException(nameof(tempKey));

            return Ok(await _userService.ResetPassword(tempKey, newPassword));
        }

        /// <summary>
        /// Puts the change password.
        /// </summary>
        /// <param name="userId">The temporary key.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        [HttpPut("change-password/{userId:int}/{oldPassword}/{newPassword}")]
        public async Task<IActionResult> PutChangePassword(int userId, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentNullException(nameof(newPassword));

            var user = await _userService.GetById(userId);

            if (user.Password != EncryptionHelper.HashPassword(oldPassword))
                return Ok(new { errorDescription = "The old password you entered is incorrect. Please try again." });

            return Ok(await _userService.ChangePassword(userId, newPassword));
        }

        /// <summary>
        /// Puts the reset password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        [HttpPut("reset-password/{userId:int}/{newPassword}")]
        [ProducesResponseType(typeof(ApplicationCore.Entities.Security.User), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutResetPassword(int userId, string newPassword)
        {
            return Ok(await _userService.ChangePassword(userId, newPassword));
        }

        /// <summary>
        /// Sends notification for the role.
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="id"></param>
        /// <param name="assetName"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost("asset-profile-notif")]
        public IActionResult PostNotifRole([FromBody] NotifRoleDTO notifRoleDTO)
        {
            List<string> allEmails = new List<string>();

            var settings = _settingsService.GetById(1);
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            foreach (var roleId in notifRoleDTO.RoleIds)
            {
                var emails = _userRoleService.GetUserEmailsByRole(roleId);
                var role = _roleService.GetById(roleId);
                if (emails == null)
                    return Ok($"Email doesn't exist for role ID {roleId}.");

                allEmails.AddRange(emails);
                string content = GenerateEmailContent(roleId, role.Name, notifRoleDTO.AssetName, notifRoleDTO.Id, settings.EmailAddress, settings.BaseUrl, notifRoleDTO.EditMode, notifRoleDTO.isAdmin);

                foreach (var email in allEmails.Distinct())
                {
                    if (!_emailService.SendEmail(email, "Notification Role", content))
                    {
                        return Ok($"Email failed!");
                    }
                }
            }

            return Ok(allEmails.Distinct());
        }

        #endregion Put

        private string GenerateEmailContent(int roleId, string roleName, string assetName, int? id, string supportEmail, string baseUrl, bool editMode, bool isAdmin)
        {
            string content;
            RoleEnum role = (RoleEnum)roleId;

            if ((role == RoleEnum.ARMDLibrarian && isAdmin || role == RoleEnum.PADLibrarian) && isAdmin && !editMode )
            {
                content = $"<h3>Dear {roleName},</h3><br/>" +
              $"Hi Librarian, information for {assetName} was added by Administrator. You can now view the additional data.<br/><br/>" +
              $"If you have any issues, please contact FAIS Support at {supportEmail}.<br/><br/>" +
              $"For direct access, copy and paste the following link into your browser: {baseUrl}/apps/asset-profile/edit/{id}<br/><br/>" +
              "Thank you,<br/>" + "Site Admin";
            }

            else if ((role == RoleEnum.ARMDLibrarian || role == RoleEnum.PADLibrarian) && isAdmin && editMode)
            {
                content = $"<h3>Dear {roleName}!,</h3><br/>" +
              $"The asset {assetName} has been updated by Administrator. Please review the changes.<br/><br/>" +
              $"If you have any questions, please contact FAIS Support at {supportEmail}.<br/><br/>" +
              $"To view the updated asset, copy and paste the following link into your browser: {baseUrl}/apps/asset-profile/edit/{id}<br/><br/>" +
              "Thank you,<br/>" + "Site Admin";
            }
            else if (role == RoleEnum.ARMDLibrarian)
            {
                content = $"<h3>Dear {roleName},</h3><br/>" +
                  $"Hi Armd, information for {assetName} was added. You can now view the additional data.<br/><br/>" +
                  $"If you have any issues, please contact FAIS Support at {supportEmail}.<br/><br/>" +
                  $"For direct access, copy and paste the following link into your browser: {baseUrl}/apps/asset-profile/edit/{id}<br/><br/>" +
                  "Thank you,<br/>" + "Site Admin";
            }

            else if ((role == RoleEnum.PADLibrarian || role == RoleEnum.ARMDLibrarian) && editMode)
            {
                content = $"<h3>Dear {roleName}!,</h3><br/>" +
                   $"The asset {assetName} has been updated. Please review the changes.<br/><br/>" +
                   $"If you have any questions, please contact FAIS Support at {supportEmail}.<br/><br/>" +
                   $"To view the updated asset, copy and paste the following link into your browser: {baseUrl}/apps/asset-profile/edit/{id}<br/><br/>" +
                   "Thank you,<br/>" + "Site Admin";
            }
            else
            {
                string htmlTemplatePath = _configuration.GetSection("EmailTemplatePath")["NotifRole"];
                if (!System.IO.File.Exists(htmlTemplatePath))
                    throw new FileNotFoundException(nameof(htmlTemplatePath));

                content = System.IO.File.ReadAllText(htmlTemplatePath);
                content = content.Replace("${role}", roleName);
                content = content.Replace("${supportemail}", supportEmail);
                content = content.Replace("${baseurl}", baseUrl);
                content = content.Replace("${url}", $"{baseUrl}/apps/asset-profile/edit/{id}");
                content = content.Replace("${assetname}", assetName);
            }
            return content;
        }
    }
}

