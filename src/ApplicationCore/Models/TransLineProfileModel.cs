using DocumentFormat.OpenXml.Bibliography;
using System;

namespace FAIS.ApplicationCore.Models
{
    public class TransLineProfileModel
    {
        public int Id { get; set; }
        public string LineStretch { get; set; }
        public long VoltageId { get; set; }
        public long TotalStructures { get; set; }
        public int NoOfCircuit { get; set; }
        public long RouteLength { get; set; }
        public Year InstallationYear { get; set; }
        public bool IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
