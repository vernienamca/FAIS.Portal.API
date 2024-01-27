using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class Users : BaseEntity<int>
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
        public int PositionId { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int? DivisionId { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public int? OupFgId { get; set; }

        [DataMember]
        public string Photo { get; set; }

        [DataMember]
        public string SessionId { get; set; }

        [DataMember]
        public int SignInAttempts { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public DateTime? DateExpired { get; set; }

        [DataMember]
        public string TempKey { get; set; }

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
