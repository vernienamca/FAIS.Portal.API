using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities
{
    public class TransLineProfile : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string LineStretch { get; set; }
        [DataMember]
        public long VoltageId { get; set; }
        [DataMember]
        public int ST { get; set; }
        [DataMember]
        public int SP { get; set; }
        [DataMember]
        public int CP { get; set; }
        [DataMember]
        public int WP{ get; set; }
        [DataMember]
        public long TotalStructures { get; set; }
        [DataMember]
        public long NoOfCircuit { get; set; }
        [DataMember]
        public long RouteLength { get; set; }
        //[DataMember]
        //public Year InstallationYear { get; set; }
        [DataMember]
        public string IsActive { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
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
