using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class User : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmployeeNumber { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public decimal PositionId { get; set; }

        [DataMember]
        public decimal? DivisionId { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public decimal MobileNumber { get; set; }

        [DataMember]
        public decimal? OupFgId { get; set; }

        [DataMember]
        public string Photo { get; set; }

        [DataMember]
        public decimal? SessionId { get; set; }

        [DataMember]
        public decimal SignInAttempts { get; set; }

        [DataMember]
        public decimal StatusCode { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public DateTime? DateExpired { get; set; }

        [DataMember]
        public decimal CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public decimal? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        [DataMember]
        public string TempKey { get; set; }
    }
}
