using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime? DateExpired { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        public IReadOnlyCollection<string> TAFGs { get; set; }
        public string OUFG { get; set; }
        public int Status { get; set; }
        public string Photo { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? LastLoginDate {get;set;} 
        public string EmailAddress { get;set;  }
    }
}
