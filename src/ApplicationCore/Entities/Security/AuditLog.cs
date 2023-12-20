using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class AuditLog : BaseEntity<decimal>
    {
        [DataMember]
        public decimal Id { get; set; }
        [DataMember]
        public decimal ModuleSeq { get; set; }
        [DataMember]
        public string Activity { get; set; }
        [DataMember]
        public string OldValues { get; set; }
        [DataMember]
        public string NewValues { get; set; }
        [DataMember]
        public string IpAddress { get; set; }
        [DataMember]
        public decimal UserCreated { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
    }
}
