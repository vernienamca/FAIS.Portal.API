using System.Runtime.Serialization;
using System;

namespace FAIS.Portal.API.Models
{
    public class UserModel
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public decimal MobileNumber { get; set; }
        public string Photo { get; set; }
        public decimal SignInAttempts { get; set; }
        public decimal StatusCode { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime? DateExpired { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
