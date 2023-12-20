using System.Runtime.Serialization;
using System;

namespace FAIS.Portal.API.Models
{
    public class AuditLogModel
    {
        public decimal Id { get; set; }
        public decimal ModuleSeq { get; set; }
        public string Activity { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string IpAddress { get; set; }
        public decimal UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
