using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.DTOs
{
    public class SettingsDTO
    {
        public int Id { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ServerName { get; set; }
        public int SMTPPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
        public int MaxSignOnAttempts { get; set; }
        public int ExpiresIn { get; set; }
        public int MinPasswordLength { get; set; }
        public int MinSpecialCharacters { get; set; }
        public int EnforcePasswordHistory { get; set; }
        public int ActivationLinkExpiresIn { get; set; }
        public string BaseUrl { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
