using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class AuditLog : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public int ModuleSeq { get; set; }
        
        [DataMember]
        public string Activity { get; set; }
        
        [DataMember]
        public string OldValues { get; set; }
        
        [DataMember]
        public string NewValues { get; set; }
        
        [DataMember]
        public string IpAddress { get; set; }
        
        [DataMember]
        public int CreatedBy { get; set; }
        
        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
