using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class BusinessProcessModel
    {
        public int Id { get; set; }
        public string BusinessProcessName { get; set; }
        public string Description { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
