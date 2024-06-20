using FAIS.ApplicationCore.AuditTrail;
using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class CostCenter : BaseEntity<string>
    {
        [DataMember]
        public string FGCode { get; set; }
        [DataMember]
        public string MCNumber { get; set; }
        [DataMember]
        public string LongName { get; set; }
        [DataMember]
        public string ShortName { get; set; }
    }
}
