using System.Runtime.Serialization;
using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class UserDTO
    {
        public decimal Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmployeeNumber { get; set; }

        public string UserName { get; set; }

        public decimal PositionId { get; set; }

        public decimal DivisionId { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public decimal MobileNumber { get; set; }

        public decimal OupFgId { get; set; }

        public string? Photo { get; set; }

        public decimal? SessionId { get; set; }

        public decimal SignInAttempts { get; set; }

        public decimal StatusCode { get; set; }

        public DateTime StatusDate { get; set; }

        public DateTime? DateExpired { get; set; }

        public decimal CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int LoginStatus { get; set; }
        public string TempKey { get; set; }
        public string positionName { get; set; }
        public string divisionName { get; set; }
    }
}
