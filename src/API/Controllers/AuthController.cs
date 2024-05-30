using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Enumeration.LoginEnum;
using Microsoft.AspNetCore.Http;
using FAIS.ApplicationCore.Enumeration;

namespace FAIS.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Variables

        private readonly TokenKeys _tokenOptions;
        private readonly ISettingsService _settingsService;
        private readonly IUserService _userService;
        private readonly IAuditLogService _auditLogService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// <param name="tokenOptions">The token options.</param>
        /// <param name="settingsService">The settings service.</param>
        /// <param name="auditLogService">The audit log service.</param>
        /// </summary>
        public AuthController(IOptions<TokenKeys> tokenOptions
          , ISettingsService settingsService
          , IUserService userService
          , IAuditLogService auditLogService)
        {
            _tokenOptions = tokenOptions.Value;
            _settingsService = settingsService;
            _userService = userService;
            _auditLogService = auditLogService;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        /// Authenticates the user login credential.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [HttpGet("authenticate")]
        [ProducesResponseType(typeof(IReadOnlyCollection<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AuthenticateUser([FromQuery]string username, [FromQuery]string password)
        {
            try
            {
                var userDto = new UserDTO();

                var user = await _userService.GetByUserName(username);

                if (user == null)
                    return Ok(new { errorDescription = "Invalid username or password combination. Please try again." });

                userDto.Id = user.Id;

                var settings = _settingsService.GetById(1);

                if (settings == null)
                    return Ok(new { errorDescription = "No system parameter setup yet in the system." });

                if (DateTime.Today >= user.DateExpired)
                    return Ok(new { errorDescription = "Your account has expired. Please contact your system administrator." });

                if (user.StatusCode == (int)UserStatusEnum.Inactive)
                    return Ok(new { errorDescription = "Your account is inactive. Please contact your system administrator." });

                if (user.StatusCode == (int)UserStatusEnum.Locked)
                    return Ok(new { errorDescription = "Your account has been locked. Please contact your system administrator." });

                if (user.SignInAttempts >= settings.MaxSignOnAttempts)
                {
                    await _userService.LockAccount(userDto.Id);

                    return Ok(new { errorDescription = "You've reached the maximum login limit. Your account has been locked." });
                }

                if (user.Password != EncryptionHelper.HashPassword(password))
                {
                    await _userService.UpdateSignInAttempts(userDto);

                    await _userService.AddLoginHistory(userDto.Id, username, true);

                    return Ok(new { errorDescription = "Invalid username or password combination. Please try again." });
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: _tokenOptions.Issuer,
                    audience: _tokenOptions.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(_tokenOptions.ExpiresInMinutes),
                    signingCredentials: signinCredentials
                );

                userDto.LoginStatus = (int)LoginStatus.Success;

                await _userService.UpdateSignInAttempts(userDto);

                await _userService.AddLoginHistory(userDto.Id, username);

                await _auditLogService.Add(new AuditLogDTO()
                {
                    ModuleSeq = 18,
                    Activity = "Login to the system",
                    IpAddress = GeoLocationHelpers.GetClientIpAddress(),
                    CreatedBy = userDto.Id,
                    CreatedAt = DateTime.Now
                });

                return Ok(new { userId = user.Id, isForcePasswordChange = user.ForcePasswordChange, accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
            }
            catch (Exception)
            {
                return Ok(new { errorDescription = "Invalid username or password combination. Please try again." });
            }
        }

        /// <summary>
        /// Gets the test end-point value.
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetTest()
        {
            return Ok("This is a test api");
        }

        #endregion Get
    }
}