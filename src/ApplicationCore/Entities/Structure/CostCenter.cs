using FAIS.ApplicationCore.AuditTrail;
using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    [Auditable]
    public class CostCenter : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FGCode { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
