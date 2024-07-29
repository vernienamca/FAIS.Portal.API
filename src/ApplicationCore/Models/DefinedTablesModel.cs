using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class DefinedTablesModel
    {
        public int Id { get; set; }
        public string BusinessProcessId { get; set; }
        public string TableName { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
