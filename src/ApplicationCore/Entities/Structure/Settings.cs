using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Settings : BaseEntity<int>
    {
        [DataMember]
        public decimal Id { get; set; }

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
        public decimal MinPasswordLength { get; set; }

        [DataMember]
        public decimal MinSpecialCharacters { get; set; }

        [DataMember]
        public decimal PasswordExpiry { get; set; }

        [DataMember]
        public decimal IdleTime { get; set; }

        [DataMember]
        public decimal EnforcePasswordHistory { get; set; }

        [DataMember]
        public decimal MaxSignOnAttempts { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
