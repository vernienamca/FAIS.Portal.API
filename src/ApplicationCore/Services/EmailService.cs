using FAIS.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;

namespace FAIS.ApplicationCore.Services
{
    public class EmailService : IEmailService
    {
        #region Variables

        private readonly ISettingsRepository _settingsRepository;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// <param name="settingsRepository">The settings repository.</param>
        /// </summary>
        public EmailService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        #endregion Constructor

        /// <summary>
        /// Sends email to target email address.
        /// </summary>
        /// <param name="emailAddress">The target email address.</param>
        /// <param name="subject">The email subject.</param>
        /// <param name="content">The content body.</param>
        public bool SendEmail(string emailAddress, string subject, string content, IReadOnlyCollection<string> ccRecipients) 
        {
            var settings = _settingsRepository.GetById(1);

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(settings.SMTPFromEmail, settings.SMTPDisplayName)
                };
                mail.To.Add(new MailAddress(emailAddress));
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = content;

                if (ccRecipients != null)
                {
                    foreach (var cc in ccRecipients)
                    {
                        mail.CC.Add(cc);
                    }
                }


                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Port = settings.SMTPPort.Value,
                    Host = settings.SMTPServerName,
                    EnableSsl = settings.SMTPEnableSSL == 'Y',
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(settings.SMTPFromEmail, settings.SMTPPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                smtp.Send(mail);
            }
            catch (SmtpFailedRecipientException)
            {
                return false;
            }

            return true;
        }
    }
}