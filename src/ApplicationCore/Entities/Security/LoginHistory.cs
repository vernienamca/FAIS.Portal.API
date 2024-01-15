using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class LoginHistory : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public char IsFailed { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
