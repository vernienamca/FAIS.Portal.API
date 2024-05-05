using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class TransmissionLineProfileDTO
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
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public class AddTransmissionLineProfileDTO
    {
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
        public DateTime StatusDate { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public class UpdateTransmissionLineProfileDTO
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
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
