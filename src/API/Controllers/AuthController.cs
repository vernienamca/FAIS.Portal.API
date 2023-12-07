using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Enumeration.LoginEnum;
using FAIS.ApplicationCore.Entities.Structure;

namespace FAIS.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class AuthController : ControllerBase
    {
        #region Variables

        private readonly TokenKeys _tokenOptions;
        private readonly ILogger<AuthController> _logger;
        private readonly ISettingsService _settingsService;
        private readonly IUserService _userService;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        public AuthController(IOptions<TokenKeys> tokenOptions
          , ILogger<AuthController> logger
          , ISettingsService settingsService
          , IUserService userService)
        {
            _tokenOptions = tokenOptions.Value;
            _logger = logger;
            _settingsService = settingsService;
            _userService = userService;
        }

        #endregion Constructor

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromQuery]string username, [FromQuery]string password)
        {
            return Ok();

            //try
            //{
            //    UserDTO userDTO = new UserDTO();

            //    var fmisUser = _fmisUserService.GetByUsername(username);

            //    if (fmisUser != null)
            //    {
            //        userDTO.UserName = username;

            //        var settings = _settingsService.GetById(1).Result;

            //        if (settings != null)
            //        {
            //            if (DateTime.Today <= fmisUser.ExpirationDate)
            //            {
            //                var user = _userService.GetByUsername(fmisUser.Username);

            //                UserDTO userDto = new UserDTO()
            //                {
            //                    LastName = fmisUser.LastName,
            //                    FirstName = fmisUser.FirstName,
            //                    UserName = fmisUser.Username,
            //                    Password = fmisUser.Password,
            //                    EmailAddress = fmisUser.Email,
            //                    PhoneNumber = "(02) 8912-4526",
            //                    Address = "Camp General Emilio Aguinaldo 1100 Quezon City, Philippines",
            //                    UserStatus = (int)UserStatus.Active,
            //                    AvatarUrl = "empty-avatar.png",
            //                    SignOnAttempts = 0,
            //                    LoggedIn = true,
            //                    ExpirationDate = fmisUser.ExpirationDate,
            //                    CreatedBy = 1,
            //                    DateCreated = fmisUser.CreatedDate,
            //                    DateUpdated = DateTime.Now
            //                };

            //                if (user != null)
            //                {
            //                    if (user.LastName != fmisUser.LastName || user.FirstName != fmisUser.FirstName || user.Password != fmisUser.Password || 
            //                        user.ExpirationDate.Date != fmisUser.ExpirationDate.Date)
            //                    {
            //                        await _userService.Update(userDto);
            //                    }
            //                }
            //                else
            //                {
            //                    await _userService.Add(userDto);
            //                }

            //                if (user.UserStatus != (int)UserStatus.Inactive)
            //                {
            //                    if (user.UserStatus != (int)UserStatus.Locked)
            //                    {
            //                        if (user.SignOnAttempts <= settings.MaxSignOnAttempts)
            //                        {
            //                            if (user.Password == EncryptionHelper.HashPassword(password))
            //                            {
            //                                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
            //                                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //                                var tokenOptions = new JwtSecurityToken(
            //                                    issuer: _tokenOptions.Issuer,
            //                                    audience: _tokenOptions.Audience,
            //                                    claims: new List<Claim>(),
            //                                    expires: DateTime.Now.AddMinutes(_tokenOptions.ExpiresInMinutes),
            //                                    signingCredentials: signinCredentials
            //                                );

            //                                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            //                                userDTO.LoginStatus = (int)LoginStatus.Success;

            //                                await _userService.UpdateSignOnAttempts(userDTO);

            //                                return Ok(new { userId = user.Id, token = tokenString, user.FirstName, user.LastName, user.EmailAddress });
            //                            }
            //                            else
            //                            {
            //                                await _userService.UpdateSignOnAttempts(userDTO);

            //                                return Ok(ErrorCodes.EDS_ERR_INVALID_LOGIN_NG);
            //                            }
            //                        }
            //                        else
            //                        {
            //                            await _userService.LockedAccount(userDTO);

            //                            return Ok(ErrorCodes.EDS_ERR_MAXLOGIN_LIMIT_NG);
            //                        }
            //                    }
            //                    else
            //                        return Ok(ErrorCodes.EDS_ERR_LOCKED_OUT_NG);
            //                }
            //                else
            //                    return Ok(ErrorCodes.EDS_ACCOUNT_INACTIVE_NG);
            //            }
            //            else
            //                return Ok(ErrorCodes.EDS_ERR_ACCOUNT_EXPIRED_NG);
            //        }
            //        else
            //            return Ok(ErrorCodes.EDS_ERR_NO_PARAMETER_NG);
            //    }
            //    else
            //        return Ok(ErrorCodes.EDS_ERR_INVALID_LOGIN_NG);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}
        }
    }
}