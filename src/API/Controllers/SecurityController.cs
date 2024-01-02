using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.Portal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]


    [Authorize]

    public class SecurityController : ControllerBase
    {
        private readonly IEmailService _emailService;



        private readonly FAISContext _context;

        public SecurityController(IEmailService emailService, FAISContext context)
        {
            _emailService = emailService;
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
            var tempKeyHelper = new TempKey();
            string tempKey = tempKeyHelper.GenerateTempKey();


            bool keyStored = await StoreTempKeyInDatabaseAsync(request.To, tempKey);

            if (keyStored)
            {
                _emailService.SendEmail(request, tempKey);
                return Ok("Temporary key generated, stored, and email sent successfully");
            }

            return BadRequest("Failed to store temporary key in the database");
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
            var user = await _context.Users.SingleOrDefaultAsync(u => u.TempKey == tempKey);

            if (user != null)
            {
                user.Password = EncryptionHelper.HashPassword(resetPasswordDTO.NewPassword);
                user.TempKey = null;
                await _context.SaveChangesAsync();

                return Ok("Password changed successfully");
            }

            return BadRequest("Invalid or expired tempKey");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changePasswordDTO"></param>
        /// <returns></returns>
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var user = _context.Users.FirstOrDefault(x => x.Password == EncryptionHelper.HashPassword(changePasswordDTO.OldPassword));

            if (user == null)
            {
                Debug.WriteLine("Invalid old password");
                return BadRequest("Invalid old password");
            }

            user.Password = EncryptionHelper.HashPassword(changePasswordDTO.NewPassword);
            await _context.SaveChangesAsync();
            Debug.WriteLine("Change password successfully");
            return Ok();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="tempKey"></param>
        /// <returns></returns>
        private async Task<bool> StoreTempKeyInDatabaseAsync(string email, string tempKey)
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
    }
}   
        





