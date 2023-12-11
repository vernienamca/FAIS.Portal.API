using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FAIS.Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IEmailService _emailService;
        //private readonly IJsonUpdateService _jsonupdateService;

        public SecurityController(IEmailService emailService /*IJsonUpdateService jsonUpdateService*/)
        {
            _emailService = emailService;
            //_jsonupdateService = jsonUpdateService;
        }


        [HttpPost("send-email")]
        public IActionResult SendEmail(EmailDTO request)
        {
            _emailService.SendEmail(request);

            return Ok();
        }

    }
}
