using FAIS.ApplicationCore.AuditTrail;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class Employee : BaseEntity<string>
    {
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Jg { get; set; }
        [DataMember]
        public string ChargingMC { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string EmployeeStatus { get; set; }
        [DataMember]
        public string ApplicationStatus { get; set; }
    }
}
