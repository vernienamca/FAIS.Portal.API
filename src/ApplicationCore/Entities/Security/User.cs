using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class User : BaseEntity<int>
    {
        [DataMember]
        public decimal Id { get; set; }

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
        public string Password { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public decimal MobileNumber { get; set; }
    }
}
