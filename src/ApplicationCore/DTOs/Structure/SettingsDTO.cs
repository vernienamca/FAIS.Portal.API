using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class SettingsDTO
    {        
        public int Id { get; set; }        
        public string CompanyName { get; set; }        
        public string PhoneNumber { get; set; }        
        public string EmailAddress { get; set; }        
        public string Website { get; set; }        
        public string Address { get; set; }        
        public string SMTPFromEmail { get; set; }        
        public string SMTPPassword { get; set; }        
        public string SMTPServerName { get; set; }        
        public int? SMTPPort { get; set; }        
        public char? SMTPEnableSSL { get; set; }        
        public string SMTPDisplayName { get; set; }        
        public int MinPasswordLength { get; set; }        
        public int MinSpecialCharacters { get; set; }        
        public int PasswordExpiry { get; set; }        
        public int IdleTime { get; set; }        
        public int EnforcePasswordHistory { get; set; }        
        public int MaxSignOnAttempts { get; set; }        
        public string BaseUrl { get; set; }        
        public string AuditLogsFilePath { get; set; }        
        public int CreatedBy { get; set; }        
        public DateTime CreatedAt { get; set; }        
        public int? UpdatedBy { get; set; }        
        public DateTime? UpdatedAt { get; set; }
    }
}
