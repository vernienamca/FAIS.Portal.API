using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class TransmissionLineProfileModel
    {
        public int Id { get; set; }
        public int LineStretch { get; set; }
        public int VoltageId { get; set; }
        public int ST { get; set; }
        public int SP { get; set; }
        public int CP { get; set; }
        public int WP { get; set; }
        public int? SLWT { get; set; }
        public DateTime? InstallationDate { get; set; }
        public int? RouteLength { get; set; }
        public int? NoCircuitId { get; set; }
        public int? CircuitLength { get; set; }
        public int? NoConductor { get; set; }
        public string ConductorSize { get; set; }
        public string Remarks { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
    }
}
