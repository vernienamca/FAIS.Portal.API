using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class TransLineProfileDTO
    {
        public int Id { get; set; }
        public int LineStretch { get; set; }
        public long VoltageId { get; set; }
        public int ST { get; set; }
        public int SP { get; set; }
        public int CP { get; set; }
        public int WP { get; set; }
        public long TotalStructures { get; set; }
        public long NoOfCircuit { get; set; }
        public long RouteLength { get; set; }
        public string IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
