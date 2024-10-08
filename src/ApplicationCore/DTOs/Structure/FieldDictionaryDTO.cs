﻿using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class FieldDictionaryDTO
    {
        public int Id { get; set; }
        public string BusinessProcessId { get; set; }
        public string FieldName { get; set; }
        public int? TableId { get; set; }
        public int? ColumnId { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
