using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class Versions : BaseEntity<int>
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string VersionNo { get; set; }

        [DataMember]
        public DateTime VersionDate { get; set; }

        [DataMember]
        public string Amendment { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
