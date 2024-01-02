using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class LoginHistory : BaseEntity<decimal>
    {
        [DataMember]
        public decimal Id { get; set; }

        [DataMember]
        public decimal? UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public char IsFailed { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
