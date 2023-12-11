﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromQuery]string username, [FromQuery]string password)
        {
            try
            {
                var userDto = new UserDTO();

                var user = _userService.GetByUserName(username);

                if (user == null)
                    return Ok("Invalid username or password combination. Please try again.");

                userDto.Id = user.Id;

                var settings = _settingsService.GetById(1);

                if (settings == null)
                    return Ok(new { errorDescription = "No system parameter setup yet in the system." });

                if (DateTime.Today >= user.DateExpired)
                    return Ok(new { errorDescription = "Your account has expired. Please contact your system administrator." });

                if (user.StatusCode == (int)UserStatus.Inactive)
                    return Ok(new { errorDescription = "Your account is inactive. Please contact your system administrator." });

                if (user.StatusCode == (int)UserStatus.Locked)
                    return Ok(new { errorDescription = "Your account has been locked. Please contact your system administrator." });

                if (user.SignInAttempts >= settings.MaxSignOnAttempts)
                {
                    await _userService.LockedAccount(userDto);

                    return Ok(new { errorDescription = "You've reached the maximum login limit. Your account has been locked." });
                }

                if (user.Password != EncryptionHelper.HashPassword(password))
                {
                    await _userService.UpdateSignInAttempts(userDto);

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

                return Ok(new { userId = user.Id, accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("test")]
        public string Test()
        {
            return "This is a test api.";
        }
    }
}