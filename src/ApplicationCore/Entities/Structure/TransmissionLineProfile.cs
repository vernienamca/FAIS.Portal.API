using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class TransmissionLineProfile : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string LineStretch { get; set; }
        [DataMember]
        public decimal VoltageId{ get; set; }
        [DataMember]
        public int ST { get; set; }
        [DataMember]
        public int SP { get; set; }
        [DataMember]
        public int CP { get; set; }
        [DataMember]
        public int WP { get; set; }
        [DataMember]
        public int? SLWT { get; set; }
        [DataMember]
        public DateTime? InstallationDate { get; set; }
        [DataMember]
        public int? RouteLength { get; set; }
        [DataMember]
        public int? NoCircuitId { get; set; }
        [DataMember]
        public int? CircuitLength { get; set; }
        [DataMember]
        public int? NoConductor { get; set; }

        [DataMember]
        public string ConductorSize { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public char IsActive { get; set; }
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
