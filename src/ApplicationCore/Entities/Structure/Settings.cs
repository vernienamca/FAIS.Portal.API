using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Settings : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string SMTPFromEmail { get; set; }

        [DataMember]
        public string SMTPPassword { get; set; }

        [DataMember]
        public string SMTPServerName { get; set; }

        [DataMember]
        public int? SMTPPort { get; set; }

        [DataMember]
        public char? SMTPEnableSSL { get; set; }

        [DataMember]
        public string SMTPDisplayName { get; set; }

        [DataMember]
        public int MinPasswordLength { get; set; }

        [DataMember]
        public int MinSpecialCharacters { get; set; }

        [DataMember]
        public int PasswordExpiry { get; set; }

        [DataMember]
        public decimal IdleTime { get; set; }

        [DataMember]
        public int EnforcePasswordHistory { get; set; }

        [DataMember]
        public int MaxSignOnAttempts { get; set; }

        [DataMember]
        public string BaseUrl { get; set; }

        [DataMember]
        public string AuditLogsFilePath { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
