using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class DepreciationMethodsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? BusinessProcessId { get; set; }
        public char IsSingleTransaction { get; set; }
        public int? FinalResultId { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
