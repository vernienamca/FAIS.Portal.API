using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class DefinedTableColumnsDTO
    {
        public int Id { get; set; }
        public int? DefinedTableId { get; set; }
        public string ColumnName { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }

    public class UpdateDefinedTableColumnsDTO
    {
        public int Id { get; set; }
        public int? DefinedTableId { get; set; }
        public string ColumnName { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
    }
}
