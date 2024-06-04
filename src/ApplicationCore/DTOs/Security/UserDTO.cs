using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class UserDTO
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string Division { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public IReadOnlyCollection<int> TAFG { get; set; }
        public string Photo { get; set; }
        public string SessionId { get; set; }
        public int SignInAttempts { get; set; }
        public string AccountStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime AccountExpiration { get; set; }
        public string TempKey { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int LoginStatus { get; set; }
        public string PositionName { get; set; }
        public string DivisionName { get; set; }
        public string OupFG { get; set; }
        public List<string> Region { get; set; }
        public IReadOnlyCollection<UserRoleDTO> UserRoles { get; set; }
    }
}
