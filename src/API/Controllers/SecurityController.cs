using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FAIS.ApplicationCore.Helpers;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics;

namespace FAIS.Portal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]


    //[Authorize]

    public class SecurityController : ControllerBase
    {
        private readonly IEmailService _emailService;

        private readonly IUserRepository _userRepository;

        private readonly FAISContext _context;

        public SecurityController(IEmailService emailService, IUserRepository userRepository, FAISContext context)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _context = context;

        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="request"></param>
       /// <returns></returns>

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(EmailDTO request)
        {
            try
            {
                var tempKeyHelper = new TempKey();
                string tempKey = tempKeyHelper.GenerateTempKey();
                Debug.WriteLine($"Generated Temp Key: {tempKey}");

                bool keyStored = await StoreTempKeyInDatabaseAsync(request.To, tempKey);

                if (keyStored)
                {
                  

                    // Send the email
                    _emailService.SendEmail(request,tempKey);

                    return Ok("Temporary key generated, stored, and email sent successfully");
                }

                return BadRequest("Failed to store temporary key in the database");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error sending email: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempKey"></param>
        /// <param name="resetPasswordDTO"></param>
        /// <returns></returns>
        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromQuery] string tempKey, [FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                // USE TEMPKEY THEN LINQ TO SEARCH THE USER
                var user = await _context.Users.SingleOrDefaultAsync(u => u.TempKey == tempKey);

                Debug.WriteLine($"User found with tempKey: {tempKey}");

                if (user != null)
                {

                    Debug.WriteLine($"User details: Id={user.Id}, Email={user.EmailAddress}");
                    user.Password = EncryptionHelper.HashPassword(resetPasswordDTO.NewPassword);

                    // Clear the tempKey after resetting the password or expiration?? 
                    user.TempKey = null;
                    await _context.SaveChangesAsync();

                    return Ok("congrats nabago mo na password mo");
                }

                return BadRequest("Invalid or expired tempKey");
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                Console.WriteLine($"Error resetting password: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tempKey"></param>
        /// <returns></returns>
        private async Task<bool> StoreTempKeyInDatabaseAsync(string email, string tempKey)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailAddress == email);
              
                if (user != null)
                {
                   
                    user.TempKey = tempKey;
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false; 
            }
            catch (Exception ex)
            {
      
                Debug.WriteLine($"Error storing temp key in the database: {ex.Message}");
                return false; 
            }
        }
    }
}
