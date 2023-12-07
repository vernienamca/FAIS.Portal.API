using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class PasswordHistory : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }
    }
}
