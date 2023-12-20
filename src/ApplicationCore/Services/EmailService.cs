using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using System.IO;
using System.Linq;

namespace FAIS.ApplicationCore.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
    

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDTO request, string tempKey)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = "Reset Password";


            // Read the content of the HTML template file TODO: how can I make this dynamic? 
            var templatePath = "C:\\Users\\Nieto\\Desktop\\Work\\Github-MyBusyBee\\FAIS.Portal\\src\\ApplicationCore\\Services\\EmailTemplates\\ForgotPassword.html";

            var templateContent = File.ReadAllText(templatePath);
            
            templateContent = templateContent.Replace("{{tempKey}}", tempKey); 

            // Set the HTML content as the body of the email
            email.Body = new TextPart(TextFormat.Html) { Text = templateContent };

            using var smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;

            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

   
    }
}