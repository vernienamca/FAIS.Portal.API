using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class DefinedMethodsFieldDictionaryDTO
    {
        public int Id { get; set; }
        public int DefinedMethodId { get; set; }
        public int FieldDictionaryId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
